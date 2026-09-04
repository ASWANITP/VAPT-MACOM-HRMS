// JScript File

function NumericCheck()//------------function to check whether a value is numeric
{
    var charcode = (event.which) ? event.which : event.keyCode
    if ( (charcode<=47 || charcode>57))
    {
       window.event.cancelBubble = true;
       window.event.keyCode = 0;
       return false;
    }
}//-------------------------------------------------------------------------------
function validNumber()
{
   var charcode = (event.which) ? event.which : event.keyCode
        if(!(charcode>=48 && charcode<=57))
        {                        
            window.event.cancelBubble = true;
            window.event.keyCode = 0;
            return false;
        }
}
function NumericCheckWithDot()//------------function to check whether a value is numeric
{
    var charcode = (event.which) ? event.which : event.keyCode
    if ( (charcode<46 || charcode>57))
    {
       window.event.cancelBubble = true;
       window.event.keyCode = 0;
       return false;
    }
}//-------------------------------------------------------------------------------


function AlphaNumericCheck()//------------function to check whether a value is alpha numeric
{//alert("1")
    ChangeToUpper();
    var charcode = (event.which) ? event.which : event.keyCode
    if (((charcode>=48 && charcode<=57) || (charcode>=65 && charcode<=90) || (charcode==32)|| (charcode==47)))
    {                 
     return true;  
    }
    else
    {
       window.event.cancelBubble = true;
       window.event.keyCode = 0;
       return false;
    }
    
}//-------------------------------------------------------------------------------
function panNoCheck(control)
 {
   ChangeToUpper();   
   var charcode = (event.which) ? event.which : event.keyCode   
   var len=document.getElementById(control).value.length;
     
   if(len>=10)
     {
      alert("Maximum length is 10")
      return false;
     }
   else if(len<5 || len>8)  
    {
     if(charcode>=65 && charcode<=90)
       {
        return true;
       }
      else
       {
        alert("Must be an alphabet");
        return false;
       } 
    }
   else
   {
    if((charcode>=48 && charcode<=57))
     {
      return true;
     }
     else
     {
       alert("Must be a number");
       return false;
     }
   }

 }
 
function formatAmount(amt)
{
 return Math.abs(amt).toFixed(2);
}


function ChangeToUpper()//------------function to change the value to uppercase
{    
   var charcode = (event.which) ? event.which : event.keyCode
   if ( (charcode>=97 && charcode<=122))
   {
       charcode=String.fromCharCode(charcode).toUpperCase();
       event.keyCode= charcode.charCodeAt(0)
   }
}//---------------------------------------------------------------------------------


function CheckAmount(control)
{
       var charcode = (event.which) ? event.which : event.keyCode
       if(!((charcode>=48 && charcode<=57)|| charcode==46))
        {                        
            window.event.cancelBubble = true;
            window.event.keyCode = 0;
            return false;
        }
     
        var amt;  var len;
        amt=document.getElementById(control).value;
        len=document.getElementById(control).value.length;
//        alert(amt);
//        alert(len);
        var chrDot=(amt.charAt(len-3));
        if(chrDot==".")
        { 
          if ("onselect"==false)
          return false; 
        }
        if(charcode==46)
        {
           if(amt.indexOf(".")!=-1)
           { 
               return false; 
           }           
        }

}


function returnFalse()//------------function to block typing
{    
  return false;
}//---------------------------------------------------------------------------------

function checkDate(dateFrom,dateTo,stat)
{
    var day1, day2 , day3;
    var month1, month2 , month3;
    var year1, year2, year3;
    
    var dt = new Date().format("dd/MMM/yyyy");
    var value3 = dt;
    
    if((dateFrom =="") || (dateTo == ""))
    {
     if(dateFrom =="")
       {
        dateFrom=new Date().format("dd/MMM/yyyy");
       }
    if(dateTo =="")
    {
    dateTo=new Date().format("dd/MMM/yyyy");
    }
    }
    
            value1 = dateFrom;
            value2 = dateTo;
           
            day1= value1.substring (0, value1.indexOf ("/"));
            month1 = value1.substring (value1.indexOf ("/")+1, value1.lastIndexOf ("/"));
            year1 = value1.substring (value1.lastIndexOf ("/")+1, value1.length);

            day2= value2.substring (0, value2.indexOf ("/"));
            month2 = value2.substring (value2.indexOf ("/")+1, value2.lastIndexOf ("/"));
            year2 = value2.substring (value2.lastIndexOf ("/")+1, value2.length);
            
            day3 = value3.substring (0, value3.indexOf ("/"));
            month3 = value3.substring (value3.indexOf ("/")+1, value3.lastIndexOf ("/"));
            year3 = value3.substring (value3.lastIndexOf ("/")+1, value3.length);
         
            date1 = year1+"/"+month1+"/"+day1;
            date2 = year2+"/"+month2+"/"+day2;
            date3 = year3+"/"+month3+"/"+day3;
            
            firstDate = Date.parse(date1)
            secondDate= Date.parse(date2)
            thirdDate = Date.parse(date3)
            

            msPerDay = 24 * 60 * 60 * 1000
            
            dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
            dbd1 = Math.round((thirdDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
            dbd2 = Math.round((thirdDate.valueOf()-secondDate.valueOf())/ msPerDay) ;   
            if(stat==1)
              {
              
               if (dbd1<0 || dbd2<0)
                 {
                  alert('Please Do not enter Future Date..!!');
                  return false;
                }
               
              }
              
           if(stat==2)
              {
              
               if (dbd1<dbd2)
                 {
                  alert('To Date Must be Greater than From Date');
                  return false ;
               }
              }  
          
           if(stat==3)
              {
              
               if (dbd1>0 || dbd2>0)
                 {
                  alert('Please Do not enter Past Date..!!');
                  return false;
                }
               
              }
              if (stat==4)
              {
                if (dbd>62)
                    {
                        alert("Check Date")
                        return false;
                    }
              }
       return true;       
           
   
}


function dateDiff(dateFrom,dateTo)
{
    var day1, day2 , day3;
    var month1, month2 , month3;
    var year1, year2, year3;
    
    var dt = new Date().format("dd/MMM/yyyy");
    var value3 = dt;
    
    if((dateFrom =="") || (dateTo == ""))
    {
     if(dateFrom =="")
       {
        dateFrom=new Date().format("dd/MMM/yyyy");
       }
    if(dateTo =="")
    {
    dateTo=new Date().format("dd/MMM/yyyy");
    }
    }
    
            value1 = dateFrom;
            value2 = dateTo;
           
            day1= value1.substring (0, value1.indexOf ("/"));
            month1 = value1.substring (value1.indexOf ("/")+1, value1.lastIndexOf ("/"));
            year1 = value1.substring (value1.lastIndexOf ("/")+1, value1.length);

            day2= value2.substring (0, value2.indexOf ("/"));
            month2 = value2.substring (value2.indexOf ("/")+1, value2.lastIndexOf ("/"));
            year2 = value2.substring (value2.lastIndexOf ("/")+1, value2.length);
            
            day3 = value3.substring (0, value3.indexOf ("/"));
            month3 = value3.substring (value3.indexOf ("/")+1, value3.lastIndexOf ("/"));
            year3 = value3.substring (value3.lastIndexOf ("/")+1, value3.length);
         
            date1 = year1+"/"+month1+"/"+day1;
            date2 = year2+"/"+month2+"/"+day2;
            date3 = year3+"/"+month3+"/"+day3;
            
            firstDate = Date.parse(date1)
            secondDate= Date.parse(date2)
            thirdDate = Date.parse(date3)
            

            msPerDay = 24 * 60 * 60 * 1000
            
            dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
            dbd1 = Math.round((thirdDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
            dbd2 = Math.round((thirdDate.valueOf()-secondDate.valueOf())/ msPerDay) ;   
            return dbd;           
   
}
