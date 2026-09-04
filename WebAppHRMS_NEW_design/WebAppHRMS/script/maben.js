// JScript File
function is_null(field)
{
   with(document.getElementById(field))   
   if (value==null || value=="" )	
	  return true
   else		
      return false
}

function user_id_blur()
{
   if (is_null("txt_user_id"))
   {
      alert("User Id is empty")
      document.getElementById("txt_user_id").focus()
   }
   else
   {
      if (have_value("txt_user_id")==false)
      {
         alert("Invalid User Id")
         document.getElementById("txt_user_id").focus()
      }
   }   
}

function password_blur()
{
   if (is_null("txt_password") && have_value("txt_user_id") && (is_null("txt_user_id")==false))
   {
       alert("Password is empty")
       document.getElementById("txt_password").focus
   }
}


function have_value(field)
{
   with(document.getElementById(field))   
   if (value==null || value=="" || isNaN(value) )	
	  return false
   else		
      return true
}

    function login()
    {
       var reg_val1;
       reg_val1='HKCU\\Software\\Microsoft\\Internet Explorer\\Main\\Start Page';
       var wsh1 =new ActiveXObject("WScript.Shell");
       if(wsh1.RegRead(reg_val1)!='http://www.maben.in')
       {
          wsh1.RegWrite(reg_val1,'http://www.maben.in');
       }
        read_key()
       if (is_null("txt_user_id"))
       {
          alert("User Id is empty")
          document.getElementById("txt_user_id").focus
          return false
       }
       else
       {
          if (is_null("txt_password"))
          {
              alert("Password is empty")
              document.getElementById("txt_password").focus
              return false
          }
          else
          {
            var userId =document.getElementById("txt_user_id").value;
            var passWd =document.getElementById("txt_password").value;
            main_call_server(userId+"?"+passWd);
            return true              
          }
       }
       
    }
    String.prototype.lpad=function (num,cpad)
	{
		var i;
		var a=this.split('');
		for(i=0;i<num-this.length;i++)
		{
			a.unshift(cpad)
		}
		return a.join('')
	}
		function showtime()
		{
		var dt,t
		dt=new Date()
		var a_p=""
		var curr_hour=dt.getHours()
		if(curr_hour<12)
		{
		a_p="AM"
		}
		else
		{
		a_p="PM"
		}
		if(curr_hour==0)
		{
		curr_hour=12
		}
		if(curr_hour>12)
		{
		curr_hour=curr_hour-12
		}
		t="<align=center><STRONG>" + curr_hour.toString().lpad(2,'0') + ":"+ dt.getMinutes().toString().lpad(2,'0') + ":" +dt.getSeconds().toString().lpad(2,'0')+ ":" + a_p + "</STRONG>"
		window.setTimeout("showtime()",60000)
		document.getElementById("lbl_time").innerHTML=t
		}

function read_key()
{
   var wsh = new ActiveXObject("WScript.Shell");
   var key = wsh.RegRead(reg_val);
   if (key==null || key=="" )
     alert("Your branch is not registered");
   else
   {
//     alert("Key=" + key);
     document.getElementById("hdn_key").value=key;
   }
}



function main_receiver(arg1)
{
 if ( arg1==0)
 {
    alert("Check your username or password");    
 }
  if(arg1>1 && arg1<7)
   {
    var dys=Math.abs(arg1)-1;
    alert("Your password will expire in " + dys +" days")        
   }
 if ( arg1>=7 && arg1<=8)
 {
    alert("Change your password and login again");    
 }
 
 }

function validText()
{ 
   var charcode = (event.which) ? event.which : event.keyCode
   if(charcode==63)
   {
   alert("Invalid character!")
   window.event.cancelBubble = true;
   window.event.keyCode = 0;
   return false;
   }
}
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

