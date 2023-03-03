#include "main.h"
#include "usart.h"
#include "spi_driver.h"
#include "RC522.h"
#include "delay.h"
#include "string.h"
#include "adc.h"
#include "math.h"
#define BLOCK 6
char readBlock();
char str_send[6];
void BEEP_Init(void)
{
GPIO_InitTypeDef GPIO_InitStructure;
RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOB, ENABLE);
//使能 GPIOB 端口时钟
GPIO_InitStructure.GPIO_Pin = GPIO_Pin_5; //BEEP-->GPIOA11 端口配置
GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP; //推挽输出
GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz; //速度为 50MHz
GPIO_Init(GPIOB, &GPIO_InitStructure); //根据参数初始化 GPIOA11
GPIO_SetBits(GPIOB,GPIO_Pin_5); //输出 1，关闭蜂鸣器输出
}

int main(void)
{
	u8 uid[10];
	uint8_t status;
	delay_init();
	SystemInit();//系统时钟初始化
	uart_init(9600);	 //串口初始化为9600
	BEEP_Init();
	RC522_IO_Init();
	PcdReset();
	PcdAntennaOff();
	delay_ms(2);
	PcdAntennaOn();
	while(1)
	{
  	status = readBlock(6,uid);
		if(MI_OK == status)
		{					
			PAout(11)=0;//开蜂鸣器
			delay_ms(50);//持续50毫秒
			PAout(11)=1;//关闭蜂鸣器		
			
		
			sprintf(str_send,"%02s",uid);//将获取的UID转换为2位的字符形式，并赋值给str_send
		  printf("book%s\r\n",str_send);//增加数据帧前“book”用于接收端数据解析判断
	
		}
   }
 }
char readBlock(int block,u8 *uid)
{
	
	uint8_t i;
	uint8_t Card_Type1[2];
	uint8_t Card_ID[4];
	uint8_t Card_KEY[6] = {0xff,0xff,0xff,0xff,0xff,0xff};    //{0x11,0x11,0x11,0x11,0x11,0x11};   //密码
	uint8_t Card_Data[16];
	uint8_t status;
	delay_ms(10);
	if(MI_OK==PcdRequest(0x26, Card_Type1))
	{
		uint16_t cardType = (Card_Type1[0]<<8)|Card_Type1[1];//把2个8位的数据Card_Type1[0]、Card_Type1[1]组合成一个16位的数据

		delay_ms(10);
		status = PcdAnticoll(Card_ID);//防冲撞
		if(status != MI_OK){
		//	printf("Anticoll Error\r\n");
		}else{
			
			sprintf(uid,"%02X",Card_ID[1]);
		}
		status = PcdSelect(Card_ID);  //选卡
		if(status != MI_OK){
		//	printf("Select Card Error\r\n");
		}
		status = PcdAuthState(PICC_AUTHENT1A,5,Card_KEY,Card_ID);
		if(status != MI_OK){
		//	printf("Auth State Error\r\n");
			return MI_ERR;
		}
		memset(Card_ID,1,4);
		delay_ms(15);
		PcdHalt();
		return MI_OK;
	}
}



/*********************************END OF FILE**********************************/
