#include "sys.h"
#include "rtc.h" 
#include "delay.h"
#include "stm32f10x.h"
#include "usart.h" 
#include <string.h>
#include "JLX12864.h"
u8 t=0;	 
char time_str[8];
u8 light_flag,light_time_count;
u8 read_flag1,read_flag1_count,read_flag2,err_flag,err_count,clear_id_count,clear_id_flag;
u8 now_time[2]; //调时间标志
tm timer;//时钟结构体 	   
//实时时钟配置
//初始化RTC时钟,同时检测时钟是否工作正常
//BKP->DR1用于保存是否第一次配置的设置
//返回0:正常
//其他:错误代码
void show_time(void)
{
	
	  RTC_Get();//更新时间 	
    now_time[0]=timer.hour;
	  now_time[1]=timer.min;
//	if((timer.hour>=20&&timer.hour<=23)||(timer.hour<=5))
//		yejia_flag=1;
//	else yejia_flag=0;
	  sprintf(time_str,"%02d-%02d %02d:%02d:%02d",timer.w_month,timer.w_date,timer.hour,timer.min ,timer.sec);		/*使用c标准库把变量转化成字符串*/
//	  display_num_string(3,41,0x80,0,2,timer.hour);//第三个参数是下划线
//		display_string_8x16(3,57,":");	
//    display_num_string(3,65,0x80,0,2,timer.min);
//		display_string_8x16(3,81,":");		
//    display_num_string(3,89,0x80,0,2,timer.sec);		
}
void RTC_NVIC_Config(void)
{	
     NVIC_InitTypeDef NVIC_InitStructure;
	   NVIC_InitStructure.NVIC_IRQChannel = RTC_IRQn;		//RTC全局中断
	   NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;	//先占优先级1位,从优先级3位
	   NVIC_InitStructure.NVIC_IRQChannelSubPriority = 1;	//先占优先级0位,从优先级4位
	   NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;		//使能该通道中断
	   NVIC_Init(&NVIC_InitStructure);		//根据NVIC_InitStruct中指定的参数初始化外设NVIC寄存器
}
u8 RTC_Init(void)
{
	//检查是不是第一次配置时钟
	u8 temp=0;
	if(BKP->DR1!=0X5050)//第一次配置
	{	 
	  	RCC->APB1ENR|=1<<28;     //使能电源时钟	    
		RCC->APB1ENR|=1<<27;     //使能备份时钟	    
		PWR->CR|=1<<8;           //取消备份区写保护
		RCC->BDCR|=1<<16;        //备份区域软复位	   
		RCC->BDCR&=~(1<<16);     //备份区域软复位结束	  	 
	    RCC->BDCR|=1<<0;         //开启外部低速振荡器 
	    while((!(RCC->BDCR&0X02))&&temp<250)//等待外部时钟就绪	 
		{
			temp++;
			delay_ms(10);
		};
		if(temp>=250)return 1;//初始化时钟失败,晶振有问题	    

		RCC->BDCR|=1<<8; //LSI作为RTC时钟 	    
		RCC->BDCR|=1<<15;//RTC时钟使能	  
	  	while(!(RTC->CRL&(1<<5))) ;//等待RTC寄存器操作完成	 
    	while(!(RTC->CRL&(1<<3)));//等待RTC寄存器同步  
    	RTC->CRH|=0X01;  		  //允许秒中断
    	while(!(RTC->CRL&(1<<5)));//等待RTC寄存器操作完成	 
		RTC->CRL|=1<<4;              //允许配置	   
		RTC->PRLH=0X0000;
		RTC->PRLL=32767;             //时钟周期设置(有待观察,看是否跑慢了?)理论值：32767										 
//		Auto_Time_Set();
			RTC_Set(2016,3,13,10,0,0); //设置时间	 
		RTC->CRL&=~(1<<4);           //配置更新
		while(!(RTC->CRL&(1<<5)));   //等待RTC寄存器操作完成		 									  
		BKP->DR1=0X5050;
		//BKP_Write(1,0X5050);;//在寄存器1标记已经开启了 
		//printf("FIRST TIME\n");
	}else//系统继续计时
	{
    	while(!(RTC->CRL&(1<<3)));//等待RTC寄存器同步  
    //	RTC->CRH|=0X01;  		  //允许秒中断
		RTC->CRH|=0X03;  		  //允许秒和闹钟中断
    	while(!(RTC->CRL&(1<<5)));//等待RTC寄存器操作完成
		//printf("OK\n");
	}		    				  
//	MY_NVIC_Init(0,0,RTC_IRQChannel,2);//RTC,G2,P2,S2.优先级最低
     RTC_NVIC_Config();
     
	RTC_Get();//更新时间 
	return 0; //ok
}
//RTC中断服务函数		 
//const u8* Week[2][7]=
//{
//{"Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"},
//{"日","一","二","三","四","五","六"}
//};					    
//RTC时钟中断
//每秒触发一次   
void RTC_IRQHandler(void)
{


if(light_flag==1)//有按键按下的时候背光开启10s
{
	LEDA=1;
	light_time_count++;
	if(light_time_count==6)
	{
		light_time_count=0;
		//LEDA=0;
		light_flag=0;
	}
}
if(read_flag1==1)//接收到用户刷卡信息的时候
{
	read_flag1_count++;
	if(read_flag1_count==3)
	{
		read_flag1_count=0;
		display_GB2312_string(3,57,0,"      ");
		display_GB2312_string(5,73,0,"      ");
		read_flag1=0;
	}
	
}

if(err_flag==1)//接收到用户刷卡信息的时候
{
	err_count++;
	if(err_count==3)
	{
		err_count=0;
		display_GB2312_string(3,1,0,"用户名:        ");

		err_flag=0;
	}
	
}

if(clear_id_flag==1)//接收到用户刷卡信息的时候
{
	clear_id_count++;
	if(clear_id_count==4)
	{
		clear_id_count=0;
    display_GB2312_string(1,1,0,"用户ID:00"); 
		clear_id_flag=0;
	}
	
}




	if(RTC->CRL&0x0001)//秒钟中断
	{							
		RTC_Get();//更新时间 	 
		show_time();
 	}
	if(RTC->CRL&0x0002)//闹钟中断
	{
		//printf("Alarm!\n");	
		RTC->CRL&=~(0x0002);//清闹钟中断
		}
    RTC->CRL&=0X0FFA;         //清除溢出，秒钟中断标志
	while(!(RTC->CRL&(1<<5)));//等待RTC寄存器操作完成		   							 	   	 
}
//判断是否是闰年函数
//月份   1  2  3  4  5  6  7  8  9  10 11 12
//闰年   31 29 31 30 31 30 31 31 30 31 30 31
//非闰年 31 28 31 30 31 30 31 31 30 31 30 31
//输入:年份
//输出:该年份是不是闰年.1,是.0,不是
u8 Is_Leap_Year(u16 year)
{			  
	if(year%4==0) //必须能被4整除
	{ 
		if(year%100==0) 
		{ 
			if(year%400==0)return 1;//如果以00结尾,还要能被400整除 	   
			else return 0;   
		}else return 1;   
	}else return 0;	
}	 			   
//设置时钟
//把输入的时钟转换为秒钟
//以1970年1月1日为基准
//1970~2099年为合法年份
//返回值:0,成功;其他:错误代码.
//月份数据表											 
u8 const table_week[12]={0,3,3,6,1,4,6,2,5,0,3,5}; //月修正数据表	  
//平年的月份日期表
const u8 mon_table[12]={31,28,31,30,31,30,31,31,30,31,30,31};

u8 RTC_Set(u16 syear,u8 smon,u8 sday,u8 hour,u8 min,u8 sec)
{
	u16 t;
	u32 seccount=0;
	if(syear<1970||syear>2099)return 1;	   
	for(t=1970;t<syear;t++)	//把所有年份的秒钟相加
	{
		if(Is_Leap_Year(t))seccount+=31622400;//闰年的秒钟数
		else seccount+=31536000;			  //平年的秒钟数
	}
	smon-=1;
	for(t=0;t<smon;t++)	   //把前面月份的秒钟数相加
	{
		seccount+=(u32)mon_table[t]*86400;//月份秒钟数相加
		if(Is_Leap_Year(syear)&&t==1)seccount+=86400;//闰年2月份增加一天的秒钟数	   
	}
	seccount+=(u32)(sday-1)*86400;//把前面日期的秒钟数相加 
	seccount+=(u32)hour*3600;//小时秒钟数
    seccount+=(u32)min*60;	 //分钟秒钟数
	seccount+=sec;//最后的秒钟加上去
													    
	//设置时钟
    RCC->APB1ENR|=1<<28;//使能电源时钟
    RCC->APB1ENR|=1<<27;//使能备份时钟
	PWR->CR|=1<<8;    //取消备份区写保护
	//上面三步是必须的!
	RTC->CRL|=1<<4;   //允许配置 
	RTC->CNTL=seccount&0xffff;
	RTC->CNTH=seccount>>16;
	RTC->CRL&=~(1<<4);//配置更新
	while(!(RTC->CRL&(1<<5)));//等待RTC寄存器操作完成  	
	return 0;	    
}



u8 RTC_Set_Alr(u16 syear,u8 smon,u8 sday,u8 hour,u8 min,u8 sec)
{
	u16 t;
	u32 seccount=0;
	if(syear<1970||syear>2099)return 1;	   
	for(t=1970;t<syear;t++)	//把所有年份的秒钟相加
	{
		if(Is_Leap_Year(t))seccount+=31622400;//闰年的秒钟数
		else seccount+=31536000;			  //平年的秒钟数
	}
	smon-=1;
	for(t=0;t<smon;t++)	   //把前面月份的秒钟数相加
	{
		seccount+=(u32)mon_table[t]*86400;//月份秒钟数相加
		if(Is_Leap_Year(syear)&&t==1)seccount+=86400;//闰年2月份增加一天的秒钟数	   
	}
	seccount+=(u32)(sday-1)*86400;//把前面日期的秒钟数相加 
	seccount+=(u32)hour*3600;//小时秒钟数
    seccount+=(u32)min*60;	 //分钟秒钟数
	seccount+=sec;//最后的秒钟加上去
													    
	//设置时钟
    RCC->APB1ENR|=1<<28;//使能电源时钟
    RCC->APB1ENR|=1<<27;//使能备份时钟
	PWR->CR|=1<<8;    //取消备份区写保护
	//上面三步是必须的!
	RTC->CRL|=1<<4;   //允许配置 
	RTC->ALRL=seccount&0xffff;
	RTC->ALRH=seccount>>16;
	RTC->CRL&=~(1<<4);//配置更新
	while(!(RTC->CRL&(1<<5)));//等待RTC寄存器操作完成  	
	return 0;	    
}


//得到当前的时间
//返回值:0,成功;其他:错误代码.
u8 RTC_Get(void)
{
	static u16 daycnt=0;
	u32 timecount=0; 
	u32 temp=0;
	u16 temp1=0;	  
	   
	timecount=RTC->CNTH;//得到计数器中的值(秒钟数)
	timecount<<=16;
	timecount+=RTC->CNTL;			 

	temp=timecount/86400;   //得到天数(秒钟数对应的)
	if(daycnt!=temp)//超过一天了
	{	  
		daycnt=temp;
		temp1=1970;	//从1970年开始
		while(temp>=365)
		{				 
			if(Is_Leap_Year(temp1))//是闰年
			{
				if(temp>=366)temp-=366;//闰年的秒钟数
				else break;  
			}
			else temp-=365;	  //平年 
			temp1++;  
		}   
		timer.w_year=temp1;//得到年份
		temp1=0;
		while(temp>=28)//超过了一个月
		{
			if(Is_Leap_Year(timer.w_year)&&temp1==1)//当年是不是闰年/2月份
			{
				if(temp>=29)temp-=29;//闰年的秒钟数
				else break; 
			}
			else 
			{
				if(temp>=mon_table[temp1])temp-=mon_table[temp1];//平年
				else break;
			}
			temp1++;  
		}
		timer.w_month=temp1+1;//得到月份
		timer.w_date=temp+1;  //得到日期 
	}
	temp=timecount%86400;     //得到秒钟数   	   
	timer.hour=temp/3600;     //小时
	timer.min=(temp%3600)/60; //分钟	
	timer.sec=(temp%3600)%60; //秒钟
	return 0;
}	 













