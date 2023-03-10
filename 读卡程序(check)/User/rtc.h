#ifndef __RTC_H
#define __RTC_H	   
#include "stm32f10x.h"

extern  u8 light_flag,light_time_count;
extern u8 read_flag1,read_flag1_count,read_flag2,err_flag,err_count,clear_id_count,clear_id_flag;//用户相关标志变量
extern u8 now_time[2];
//时间结构体
typedef struct 
{
	u8 hour;
	u8 min;
	u8 sec;			
	//公历日月年周
	u16 w_year;
	u8  w_month;
	u8  w_date;
	u8  week;		 
}tm;					 
 
extern u8 const mon_table[12];//月份日期数据表
void Disp_Time(u8 x,u8 y,u8 size);//在制定位置开始显示时间
void Disp_Week(u8 x,u8 y,u8 size,u8 lang);//在指定位置显示星期
u8 RTC_Init(void);        //初始化RTC,返回0,失败;1,成功;
u8 Is_Leap_Year(u16 year);//平年,闰年判断
u8 RTC_Get(void);         //更新时间   
u8 RTC_Get_Week(u16 year,u8 month,u8 day);
u8 RTC_Set(u16 syear,u8 smon,u8 sday,u8 hour,u8 min,u8 sec);//设置时间
u8 RTC_Set_Alr(u16 syear,u8 smon,u8 sday,u8 hour,u8 min,u8 sec);//闹钟时间设置	  
void show_time(void);
//void Auto_Time_Set(void);//设置时间为编译时间
void Delay_Time(void);
#endif




























 
