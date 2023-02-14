namespace Todoly.Views.Models;

 public class RecurrenceObject

 {

     public int RepeatType = 0; //Daily, Weekly, Monthly, Yearly recurrence

     public int SelectDays = 0; //If Daily, on every x days

     public int SelectWeeks = 0; //If Weekly on every x weeks

     public bool Weekday0 = false; //If Weekly on every Sunday

     public bool Weekday1 = false; //If Weekly on every Monday

     public bool Weekday2 = false; //If Weekly on every Tuesday

     public bool Weekday3 = false; //If Weekly on every Wednesday

     public bool Weekday4 = false; //If Weekly on every Thursday

     public bool Weekday5 = false; //If Weekly on every Friday

     public bool Weekday6 = false; //If Weekly on every Saturday

     public int SelectMonths = 0; //If Monthly, in every x Months

     public bool MonthByMonthDay = false; //If Monthly on every 2nd Monday, or last Friday, etc.

     public bool MonthByDay = false; //If Monthly and not MonthByMonthDay, on every 26th of the month

     public int SelectYears = 0; //If Yearly, in every x year. 

     public DateTime OriginalDate; //Holds the first Due date for later calculation. Never changes. 
 }
