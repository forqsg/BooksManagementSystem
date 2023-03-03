#include "delay.h"
#include "JLX12864.h"
//LCD型号：JLX12864-132PC
void JLX12864G_132_GPIOInit(void)  
{
	GPIO_InitTypeDef GPIO_InitStructure;
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA|RCC_APB2Periph_GPIOB,ENABLE);
	
	GPIO_InitStructure.GPIO_Pin=GPIO_Pin_12|GPIO_Pin_13|GPIO_Pin_14|GPIO_Pin_15;	//REST,RS,SDA,SCLK
	GPIO_InitStructure.GPIO_Mode=GPIO_Mode_Out_PP;			//推挽输出
	GPIO_InitStructure.GPIO_Speed=GPIO_Speed_50MHz;			//速度50MHZ
  GPIO_Init(GPIOB,&GPIO_InitStructure);	
	
	
	GPIO_InitStructure.GPIO_Pin=GPIO_Pin_8|GPIO_Pin_0;	//CS，LEDA
	GPIO_InitStructure.GPIO_Mode=GPIO_Mode_Out_PP;			//推挽输出
	GPIO_InitStructure.GPIO_Speed=GPIO_Speed_50MHz;			//速度50MHZ
  GPIO_Init(GPIOA,&GPIO_InitStructure);	
	
	GPIO_InitStructure.GPIO_Pin=GPIO_Pin_6|GPIO_Pin_7|GPIO_Pin_9;	//ROM_CS,ROM_SCK,ROM_IN
	GPIO_InitStructure.GPIO_Mode=GPIO_Mode_Out_PP;	//推挽输出
	GPIO_InitStructure.GPIO_Speed=GPIO_Speed_50MHz;	//速度50MHZ
  GPIO_Init(GPIOB,&GPIO_InitStructure);	
	
	GPIO_InitStructure.GPIO_Pin=GPIO_Pin_8;					//ROM_OUT
	GPIO_InitStructure.GPIO_Mode=GPIO_Mode_IPU;			//上拉输入
	GPIO_InitStructure.GPIO_Speed=GPIO_Speed_50MHz;	//速度50MHZ
  GPIO_Init(GPIOB,&GPIO_InitStructure);	
 
}
/*写指令到LCD模块*/
void transfer_command_lcd(int data1) 
{ 
	uchar i; 
	lcd_cs1=0; 
	lcd_rs=0; 
	for(i=0;i<8;i++) 
	{ 
		lcd_sclk=0; 
		delay_us(1); 
		if(data1&0x80) lcd_sid=1;
		else lcd_sid=0; 
		lcd_sclk=1; 
		delay_us(1); 
		data1=data1<<=1; 
	} 
	lcd_cs1=1; 
} 
/*写数据到LCD*/
void transfer_data_lcd(int data1) 
{ 
	uchar i; 
	lcd_cs1=0; 
	lcd_rs=1; 
	for(i=0;i<8;i++) 
	{ 
		lcd_sclk=0; 
		if(data1&0x80) lcd_sid=1; 
		else lcd_sid=0; 
		lcd_sclk=1; 
		data1=data1<<=1; 
	} 
	lcd_cs1=1; 
} 

/*LCD初始化*/
void initial_lcd() 
{ 
	lcd_reset=0;   
	delay_ms(100); 
	lcd_reset=1;    
	delay_ms(100); 
	transfer_command_lcd(0xe2); 
	delay_ms(20); 
	transfer_command_lcd(0x2c); 
	delay_ms(20); 
	transfer_command_lcd(0x2e); 
	delay_ms(20); 
	transfer_command_lcd(0x2f); 
	delay_ms(20); 
	transfer_command_lcd(0x24); 
	transfer_command_lcd(0x81); 
	transfer_command_lcd(0x15);  
	transfer_command_lcd(0xa2);
	transfer_command_lcd(0xc8); 
	transfer_command_lcd(0xa0); 
	transfer_command_lcd(0x40); 
	transfer_command_lcd(0xaf); 
} 

void lcd_address(uint page,uint column) 
{ 
	column=column-1; 
	transfer_command_lcd(0xb0+page-1); 
	transfer_command_lcd(0x10+(column>>4&0x0f)); 
	transfer_command_lcd(column&0x0f);  
} 

/*全屏清屏*/
void clear_screen() 
{ 
	unsigned char i,j; 
	for(i=0;i<9;i++) 
	{ 
		lcd_address(1+i,1); 
		for(j=0;j<224;j++) 
		{ 
			transfer_data_lcd(0x00); 
		} 
	} 
	lcd_cs1=1; 
} 

void display_128x64(uchar *dp) //显示128*64的点阵图像
{
	uint i,j;
	for(j=0;j<8;j++)
	{
		lcd_address(j+1,1);
		for (i=0;i<128;i++)
		{
			transfer_data_lcd(*dp);
			dp++;
		}
	}
}
/*显示16*16点阵图像*/
void display_graphic_16x16(uint page,uint column,uchar reverse,uchar *dp) 
{ 
	uint i,j;  
	for(j=0;j<2;j++) 
	{ 
		lcd_address(page+j,column); 
		for (i=0;i<16;i++) 
		{ 
			if(reverse==1) 
				transfer_data_lcd(~*dp);  
			else 
				transfer_data_lcd(*dp); 
			dp++; 
		}	 
	} 
} 
/*显示8*16点阵*/
void display_graphic_8x16(uint page,uchar column,uchar reverse,uchar *dp) 
{ 
	uint i,j;  
	for(j=0;j<2;j++) 
	{ 
		lcd_address(page+j,column); 
		for (i=0;i<8;i++) 
		{ 
			if(reverse==1) 
				transfer_data_lcd(~*dp); 
			else 
				transfer_data_lcd(*dp);
			dp++; 
		} 
	} 
} 
/*显示5*7点阵*/
void display_graphic_5x7(uint page,uchar column,uchar reverse,uchar *dp) 
{ 
	uint col_cnt; 
	uchar page_address; 
	uchar column_address_L,column_address_H; 
	page_address = 0xb0+page-1; 
	column_address_L =(column&0x0f)-1; 
	column_address_H =((column>>4)&0x0f)+0x10; 
	transfer_command_lcd(page_address);   	/*Set Page Address*/ 
	transfer_command_lcd(column_address_H); /*Set MSB of column Address*/ 
	transfer_command_lcd(column_address_L); /*Set LSB of column Address*/ 
	for (col_cnt=0;col_cnt<6;col_cnt++) 
	{ 
		if(reverse==1) 
			transfer_data_lcd(~*dp); 
		else 
			transfer_data_lcd(*dp); 
		dp++; 
	} 
} 
/*送指令到字库*/
void send_command_to_ROM( uchar datu ) 
{ 
	uchar i; 
	for(i=0;i<8;i++ ) 
	{ 
		if(datu&0x80) 
			Rom_IN = 1; 
		else 
			Rom_IN = 0; 
		datu = datu<<1; 
		Rom_SCK=0; 
		Rom_SCK=1; 
	} 
} 
/*从字库取汉字或字符串*/
static uchar get_data_from_ROM( ) 
{ 
	uchar i; 
	uchar ret_data=0; 
	Rom_SCK=1; 
	for(i=0;i<8;i++)
	{ 
		ROM_OUT_OUT();					//设置成输出
		Rom_OUT = 1; 
		Rom_SCK=0; 
		ret_data=ret_data<<1; 
		ROM_OUT_IN();						//设置成输入
		if( Rom_OUT_cin) 
			ret_data=ret_data+1; 
		else 
			ret_data=ret_data+0; 
		Rom_SCK=1; 
	} 
	return(ret_data); 
} 
/*从相关的联系地址读数据到buffer*/
void get_n_bytes_data_from_ROM(uchar addrHigh,uchar addrMid,uchar addrLow,uchar *pBuff,uchar DataLen ) 
{ 
	uchar i; 
	Rom_CS = 0; 
	lcd_cs1=1;  
	Rom_SCK=0; 
	send_command_to_ROM(0x03); 
	send_command_to_ROM(addrHigh); 
	send_command_to_ROM(addrMid); 
	send_command_to_ROM(addrLow); 
	for(i = 0; i < DataLen; i++ ) 
		*(pBuff+i) =get_data_from_ROM(); 
	Rom_CS = 1; 
} 

ulong fontaddr=0; 
void display_GB2312_string(uchar y,uchar x,uchar reverse,uchar *text) 
{ 
	uchar i= 0; 
	uchar addrHigh,addrMid,addrLow ; 
	uchar fontbuf[32];    
	while((text[i]>0x00)) 
	{ 
		if(((text[i]>=0xb0) &&(text[i]<=0xf7))&&(text[i+1]>=0xa1)) 
		{ 
			fontaddr = (text[i]- 0xb0)*94; 
			fontaddr += (text[i+1]-0xa1)+846; 
			fontaddr = (ulong)(fontaddr*32); 
			addrHigh = (fontaddr&0xff0000)>>16;
			addrMid = (fontaddr&0xff00)>>8; 
			addrLow = fontaddr&0xff; 
			get_n_bytes_data_from_ROM(addrHigh,addrMid,addrLow,fontbuf,32 );
			display_graphic_16x16(y,x,reverse,fontbuf);
			i+=2; 
			x+=16; 
		} 
		else if(((text[i]>=0xa1) &&(text[i]<=0xa3))&&(text[i+1]>=0xa1)) 
		{ 

			fontaddr = (text[i]- 0xa1)*94; 
			fontaddr += (text[i+1]-0xa1); 
			fontaddr = (ulong)(fontaddr*32); 
			addrHigh = (fontaddr&0xff0000)>>16; 
			addrMid = (fontaddr&0xff00)>>8; 
			addrLow = fontaddr&0xff; 
			get_n_bytes_data_from_ROM(addrHigh,addrMid,addrLow,fontbuf,32 );
			display_graphic_16x16(y,x,reverse,fontbuf);
			i+=2; 
			x+=16; 
		} 
		else if((text[i]>=0x20) &&(text[i]<=0x7e))  
		{ 
			unsigned char fontbuf[16]; 
			fontaddr = (text[i]- 0x20); 
			fontaddr = (unsigned long)(fontaddr*16); 
			fontaddr = (unsigned long)(fontaddr+0x3cf80); 
			addrHigh = (fontaddr&0xff0000)>>16; 
			addrMid = (fontaddr&0xff00)>>8; 
			addrLow = fontaddr&0xff; 
			get_n_bytes_data_from_ROM(addrHigh,addrMid,addrLow,fontbuf,16 );
			display_graphic_8x16(y,x,reverse,fontbuf);
			i+=1; 
			x+=8; 
		} 
		else 
			i++; 
	} 
} 
void display_string_5x7(uchar y,uchar x,uchar *text) 
{ 
	unsigned char i= 0; 
	unsigned char addrHigh,addrMid,addrLow ; 
	while((text[i]>0x00)) 
	{ 
		if((text[i]>=0x20) &&(text[i]<=0x7e))  
		{ 
			unsigned char fontbuf[8]; 
			fontaddr = (text[i]- 0x20); 
			fontaddr = (unsigned long)(fontaddr*8); 
			fontaddr = (unsigned long)(fontaddr+0x3bfc0); 
			addrHigh = (fontaddr&0xff0000)>>16; 
			addrMid = (fontaddr&0xff00)>>8; 
			addrLow = fontaddr&0xff; 
			get_n_bytes_data_from_ROM(addrHigh,addrMid,addrLow,fontbuf,8);
			display_graphic_5x7(y,x,0,fontbuf);
			i+=1; 
			x+=6; 
		} 
		else 
			i++;  
	}	 
}

void transfer_data(int data1) {    /*写数据到 LCD 模块*/


char i;
lcd_cs1=0;
lcd_rs=1;
for(i=0;i<8;i++)    //数据拆位
{
lcd_sclk=0;
if(data1&0x80) lcd_sid=1;
	else lcd_sid=0;
lcd_sclk=1;
data1=data1<<=1;
}
}







