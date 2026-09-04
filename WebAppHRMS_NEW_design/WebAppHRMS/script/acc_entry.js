// JScript File
var cont_name=credit_id.substr(0,credit_id.indexOf('txt'))
function number(field)
{
	var a
	//alert("sdffsaf")
	a=document.getElementById(field).value
	if (isNaN(a))
	{
		document.getElementById(field).value=""
		document.getElementById(field).focus()
	}
}

function isNumberKey(evt)
{
var charcode = (evt.which) ? evt.which : event.keyCode
    if (charcode > 31 && (charcode < 48 || charcode > 57))
    return false;

 return true;

}

function is_null(field)
{
   with(document.getElementById(field))   
   if (value==null || value=="" )	
	  return true
   else		
      return false
}

function have_value(field)
{
   with(document.getElementById(field))   
   if (value==null || value=="" || isNaN(value) )	
	  return false
   else		
      return true
}

function debit_onchange()
{
   if (is_null(cont_name+"txt_debit"))
   {
      document.getElementById(cont_name+"txt_credit").focus()
      return
   }
   if (!(have_value(cont_name+"txt_debit")))
   {
     alert("Not a number")
     document.getElementById(cont_name+"txt_debit").value=""
     document.getElementById(cont_name+"txt_debit").focus()
     return
   }
   if(document.getElementById(cont_name+"txt_debit").value<=0)
   {
     alert("You Must Enter a Positive Value")
     document.getElementById(cont_name+"txt_debit").value=""
     document.getElementById(cont_name+"txt_debit").focus()
     return
   }   
   arr=document.getElementById(cont_name+"cmb_accno").value.split("/")
   if (arr[1]==5)
   {
      alert("You can not debit this account")
      document.getElementById(cont_name+"txt_debit").value=""
      document.getElementById(cont_name+"txt_debit").focus()
      return
   }
   add_entry()
}

function formatNumber(num,dec,thou,pnt,curr1,curr2,n1,n2)
{
	var x = Math.round(num * Math.pow(10,dec));
		if (x >= 0) n1=n2='';
			var y = (''+Math.abs(x)).split('');
			var z = y.length - dec;y.splice(z, 0, pnt);
			while (z > 3)
			{
				z-=3;
				y.splice(z,0,thou);
			}
			var r = curr1+n1+y.join('')+n2+curr2;
return r;
}


function entry_error (error,context)
{
   alert(error)
}
		
function show_date(ctl_name,no_of_years)
{
   var date_str
   date_str="<TABLE id=dt_table style=WIDTH: 136px; HEIGHT: 30px cellSpacing=0 cellPadding=0 width=136 	align=left border=0>"
   date_str=date_str+"<TR>"
   date_str=date_str+"<TD style=WIDTH: 44px><SELECT id=dt_cmb_day style=WIDTH: 48px>"
   var datei
   for (datei=1;datei<=31;datei=datei+1)
   {
     date_str=date_str+"<option value="+datei+">"
     date_str=date_str+datei+"</option>"
   }
   date_str=date_str+"</SELECT></TD>"
   date_str=date_str+"<TD style=WIDTH: 49px><SELECT id=dt_cmb_month style=WIDTH: 56px>"
   date_str=date_str+"<option value=JAN>JAN</option>"
   date_str=date_str+"<option value=FEB>FEB</option>"
   date_str=date_str+"<option value=MAR>MAR</option>"
   date_str=date_str+"<option value=APR>APR</option>"
   date_str=date_str+"<option value=MAY>MAY</option>"
   date_str=date_str+"<option value=JUN>JUN</option>"
   date_str=date_str+"<option value=JUL>JUL</option>"
   date_str=date_str+"<option value=AUG>AUG</option>"
   date_str=date_str+"<option value=SEP>SEP</option>"
   date_str=date_str+"<option value=OCT>OCT</option>"
   date_str=date_str+"<option value=NOV>NOV</option>"
   date_str=date_str+"<option value=DEC>DEC</option>"
   date_str=date_str+"</SELECT></TD>"
   //date_str=date_str+"<TD><SELECT id=dt_cmb_year style=WIDTH: 57px>"
   date_str=date_str+"<TD><SELECT id=dt_cmb_year style=WIDTH: 57px onblur=descr_focus()>"
   var r_date = new Date();
   var curr_year=r_date.getFullYear()
   for (datei=curr_year-no_of_years;datei<=curr_year+no_of_years;datei=datei+1)
   {
     date_str=date_str+"<option value="+datei+">"
     date_str=date_str+datei+"</option>"
   }
   date_str=date_str+"</SELECT></TD>"
   date_str=date_str+"</TR>"
   date_str=date_str+"</TABLE>"
   document.getElementById(ctl_name).innerHTML=date_str
   document.getElementById("dt_cmb_day").selectedIndex=curr_day-1
   document.getElementById("dt_cmb_month").selectedIndex=curr_month-1
   document.getElementById("dt_cmb_year").selectedIndex=no_of_years
  }
function isControlKey(evt)
{

var charcode = (evt.which) ? evt.which : event.keyCode
//alert(charcode)
if (charcode ==126 || charcode ==33 || charcode == 47 || charcode ==92 || charcode ==94 || charcode ==42 || charcode ==13)
    return false;

 return true;

}

function entry_receiver (result,context)
{
  switch(context)
  {
    case "2":
      //alert(result)
      var bank_str
      bank_str="<table border =1><tr><td colspan=4 align=center>BANK DETAILS</td></tr>"
      bank_str=bank_str+"<td> Account</td>"
      bank_str=bank_str+"<td><select name=cmb_bank id=cmb_bank >"
      var banks
      var ind_bank
      banks=result.split("@")
      var lp_cnt
      for (lp_cnt=0;lp_cnt<banks.length-1;lp_cnt++)
      {
           ind_bank=banks[lp_cnt].split("~")
           bank_str=bank_str+"<option value="
           bank_str=bank_str+ind_bank[0]
           bank_str=bank_str+">"
           bank_str=bank_str+ind_bank[1]
           bank_str=bank_str+"</option>"
      }
      bank_str=bank_str+"</select>"
      bank_str=bank_str+"</td>"
      bank_str=bank_str+"<td> Bank Name</td><td><input type=text name=txt_bankname id=txt_bankname width=100%></td></tr>"
      bank_str=bank_str+"<tr><td>Cheque No</td>"
      bank_str=bank_str+"<td><input type=text name=txt_cheqno id=txt_cheqno width=100%></td>"
      bank_str=bank_str+"<td> Cheq date</td>"
      bank_str=bank_str+"<td>"
      bank_str=bank_str+"<DIV id=lbl_cheque_dt name=lbl_cheque_dt></DIV>"
      bank_str=bank_str+"</td></tr></table>"
      document.getElementById(cont_name+"pnl_display").innerHTML=bank_str
      document.getElementById("txt_bankname").focus()
      show_date("lbl_cheque_dt",1)
      break;
    case "3":
      //alert(result)
      var bank_str
      bank_str="<table border =1><tr><td colspan=2 align=center>BRANCH DETAILS</td></tr><tr><td>Branch Name</td><td>"
      bank_str=bank_str+"<SELECT id=cmb_subdtl name=cmb_subdtl width=100% onblur=descr_focus()>"
      var banks
      var ind_bank
      banks=result.split("@")
      var lp_cnt
      for (lp_cnt=0;lp_cnt<banks.length-1;lp_cnt++)
      {
           ind_bank=banks[lp_cnt].split("~")
           bank_str=bank_str+"<option value="
           bank_str=bank_str+ind_bank[0]
           bank_str=bank_str+">"
           bank_str=bank_str+ind_bank[1]
           bank_str=bank_str+"</option>"
      }
      bank_str=bank_str+"</select></td></tr></table>"
      document.getElementById(cont_name+"pnl_display").innerHTML=bank_str
      document.getElementById("cmb_subdtl").focus()
      break;
      /*
   case "4":
      //alert(result)
      var sub_str
      sub_str="<SELECT id=cmb_subdtl name=cmb_subdtl width=100%>"
      var banks
      var ind_bank
      banks=result.split("@")
      var lp_cnt
      for (lp_cnt=0;lp_cnt<banks.length-1;lp_cnt++)
      {
           ind_bank=banks[lp_cnt].split("~")
           bank_str=bank_str+"<option value="
           bank_str=bank_str+ind_bank[0]
           bank_str=bank_str+">"
           bank_str=bank_str+ind_bank[1]
           bank_str=bank_str+"</option>"
      }
      bank_str=bank_str+"</select>"
      break;
      */
  }
}

function credit_onchange()
{
   if (!(have_value(cont_name+"txt_credit")))
   {
     alert("Not a number")
     document.getElementById(cont_name+"txt_credit").value=""
     document.getElementById(cont_name+"txt_debit").focus()
     return
   }
   if(document.getElementById(cont_name+"txt_credit").value<=0)
   {
     alert("You Must Enter a Positive Value")
     document.getElementById(cont_name+"txt_credit").value=""
     document.getElementById(cont_name+"txt_debit").focus()
     return
   } 
   if (have_value(cont_name+"txt_debit")) 
   {
     document.getElementById(cont_name+"txt_credit").value=""
     document.getElementById(cont_name+"txt_debit").value=""
     alert("Can enter debit/credit only")
     document.getElementById(cont_name+"txt_debit").focus()
     return
   }  
   arr=document.getElementById(cont_name+"cmb_accno").value.split("/")
   switch (arr[1])
   {
     case 1:
       entry_call_server("1~"+arr[0]+"~"+"~0","1")
       break;
     case 2:
		 if (document.getElementById("txt_bankname").value=="")
		 {
          alert("Bankname Not Entered..Please Enter")
          document.getElementById("txt_bankname").focus()
          return
         }
         if (document.getElementById("txt_cheqno").value=="")  
         {
           alert("Cheque Number Not Entered...Please Enter")
           return
         }   
        showbal_dtl("6~"+arr[0]+"~"+document.getElementById("cmb_bank").value,"6")
        break;
     }      
     add_entry()
}

function check_acc()
{
  var arr
  arr=document.getElementById(cont_name+"cmb_accno").value.split("/")
  
  var st
  st=parseInt(arr[1])
  //alert(st)
  switch(st)
  {
    case 1:
       //alert(arr[1])
       document.getElementById(cont_name+"pnl_display").innerHTML="<table border =1><tr><td colspan=2 align=center>CUSTOMER DETAILS</td></tr><tr><td>Customer Name</td><td><input type=text name=txt_cusname id=txt_cusname maxlength=20 onblur=descr_focus()></td></tr></table>"
        document.getElementById("txt_cusname").focus()
       //document.getElementById(cont_name+"pnl_display").innerHTML="<table border =1><tr><td colspan=2 align=center>CUSTOMER DETAILS</td></tr><tr><td>Customer Name</td><td><input type=text name=txt_cusname id=txt_cusname maxlength=20></td></tr></table>"
       break;
    case 2:
       //alert(arr[1])
       entry_call_server("2~"+arr[0],"2")
       break;
    case 3:
       //alert(arr[1])
       entry_call_server("3~"+arr[0],"3")
       break;
    case 4 :
      //alert(arr[1])
      entry_call_server("4~"+arr[0],"4")
      break;
    default:
      document.getElementById(cont_name+"pnl_display").innerHTML=""
  }
}

function delf(cnt)
{
  
  var new_tran
  arr_vouch=document.getElementById(cont_name+"hdn_add").value.split("!")
  new_tran=""
  for (delfi=1;delfi<arr_vouch.length;delfi++)
  {
     if (delfi!=cnt)
          new_tran=new_tran+"!"+arr_vouch[delfi]
  }   
  document.getElementById(cont_name+"hdn_add").value=new_tran
  show_trans()
}

function show_trans()
{
   arr_vouch=document.getElementById(cont_name+"hdn_add").value.split("!")
   var tran_str
   tran_str=""
   var s
   var account
   var total
   var tot_db
   var tot_cr
   tot_db=0.0
   tot_cr=0.0
   tran_str="<table  width=100% border=1><tr><td colspan=4 align=center><b>TRANSACTION DETAILS</b></td></tr><tr><td><b>Account Name</b></td><td><b>Description</b></td><td><b>Debit</b></td><td><b>Credit</b></td></tr>"
   for (funi=1;funi<arr_vouch.length;funi++)
   {
     at=arr_vouch[funi]
     s=at.split("~")
     //tran_str=tran_str+"<tr>"+"<td width=176px>"+s(0)+"</td>"+"<td width=344px nowrap=false>"+s(1)+"</td>"+"<td width=88px>"+s(2)+"&nbsp;</td>"+"<td width=88px>"+s(3)+"&nbsp;</td>"+"<td><a href=javascript:delf('1')>Del</a></td>"+"</tr>"
     account=s[0].split("/")
     var des_tb
     if(account[1]==2 || account[1]==3)
     {
     des_tb=account[3]
     }
     else
     {
     des_tb=account[2]
     }
     tran_str=tran_str+"<tr>"+"<td width=397px align=left >"+des_tb+"</td>"+"<td width=303px nowrap=false align=left Font-Size=smaller>"+s[1]+"</td>"+"<td width=107px align=right>"+s[2]+"&nbsp;</td>"+"<td width=107px align=right>"+s[3]+"&nbsp;</td>"+"<td width=15px><a href=javascript:delf('" + funi + "')>Del</a></td>"+"</tr>"
     //alert(account[3])
     //alert(s[0])
     //alert(s[1])
     if (!isNaN(parseFloat (s[2])))
		{
         //tot_db=tot_db+parseFloat(formatNumber(parseFloat(s[2]),2,'','','','',''))
         tot_db=parseFloat(tot_db)+parseFloat(s[2])
      
         }
     if (!isNaN(parseFloat (s[3])))  
         //tot_cr=tot_cr+parseFloat(formatNumber(parseFloat(s[3]),2,'','','','',''))
         tot_cr=parseFloat(tot_cr)+parseFloat(s[3])
         
   }
   tot_db=parseFloat(formatNumber(parseFloat(tot_db),2,'','.','','',''))
   tot_cr=parseFloat(formatNumber(parseFloat(tot_cr),2,'','.','','',''))
   tran_str=tran_str+"<tr><td colspan=2 align=center><b>Total</b></td><td align=right>"+formatNumber(parseFloat(tot_db),2,'','.','','','')+"</td><td align=right>"+formatNumber(parseFloat(tot_cr),2,'','.','','','')+"</td></tr>" 
   //tran_str=tran_str+"<tr><td colspan=2 align=center><b>Total</b></td><td>"+tot_db+"</td><td>"+tot_cr+"</td></tr>" 
   tran_str=tran_str+"</table>"
   document.getElementById(cont_name+"pnl_tran").innerHTML=tran_str
   //document.getElementById(cont_name+"cmb_accno").focus()
 };

function tally_check()
{
  var tot_tr
  tot_tr = document.getElementById(cont_name+"hdn_add").value.split("!")
   if (tot_tr.length <= 1)
  {
     alert("You Have Not Entered Any Transaction")
     document.getElementById(cont_name+"hdn_add").value = ""
     return false;
  }
  var fi
  var ind_tr
  var tot_cr
  var tot_db
  tot_cr=0.0
  tot_db=0.0
  tot_cr.toFixed(2)
  tot_db.toFixed(2)
  for (fi = 1;fi<=(tot_tr.length- 1);fi++)
  {
    ind_tr = tot_tr[fi].split("~")
     
     if (!isNaN(parseFloat(ind_tr[2])))
        tot_cr = (Math.round(tot_cr*100)/100) + (Math.round(ind_tr[2]*100)/100)
        //tot_cr = parseFloat(tot_cr) + parseFloat(ind_tr[2])
     if (!isNaN(parseFloat(ind_tr[3])))
      tot_db = (Math.round(tot_db*100)/100) + (Math.round(ind_tr[3]*100)/100)
      //tot_db = parseFloat(tot_db) + parseFloat(ind_tr[3])
      //alert(tot_cr)
      //alert(tot_db)
  }
  tot_db=Math.round(tot_db*100)/100
  tot_cr =Math.round(tot_cr*100)/100
  if (tot_cr != tot_db )
   {
    alert( "Credits and Debits are not equal " + tot_cr + "CR " + tot_db + "DB")
    return  false
   } 
   tot_db=parseFloat(formatNumber(parseFloat(tot_db,2),'','.','','',''))
   tot_cr=parseFloat(formatNumber(parseFloat(tot_cr,2),'','.','','',''))
   
   if (document.getElementById(cont_name+"txt_nar").value == "")
   {
    alert("Please Enter Narration")
    document.getElementById(cont_name+"txt_nar").focus()
    return false 
   }  
   //document.getElementById("hidbank").value=""
   //document.getElementById(cont_name+"txt_nar").value=""
   //document.f1.submit()
 }

function add_entry()
{
   document.getElementById(cont_name+"txt_descr").style.backgroundColor=""
   /*
   if (!(have_value(cont_name+"txt_debit")) && !(have_value(cont_name+"txt_credit"))) 
   {
	 alert("Both debit and credit is zero")
	 document.getElementById("txt_debit").focus()
	 return
   }
   */
   if (document.getElementById(cont_name+"txt_descr").value=="") 
   {
      alert("Description is Empty")
      document.getElementById(cont_name+"txt_descr").style.backgroundColor="lime"
      document.getElementById(cont_name+"txt_descr").focus()
      return
   }   
    
   arr=document.getElementById(cont_name+"cmb_accno").value.split("/")
   switch (parseInt(arr[1]))
   {
     case 2:
        if (document.getElementById("txt_bankname").value=="") 
        {
          alert("Bankname Not Entered..Please Enter")
          document.getElementById("txt_bankname").focus()
          return
        }
        if (document.getElementById("txt_cheqno").value=="")  
        {
           alert("Cheque Number Not Entered...Please Enter")
           document.getElementById("txt_cheqno").focus()
           return
        }
        if (document.getElementById("cmb_bank").value==0) 
        {
         alert("BANK ACCOUNT IS NOT SELECTED")
         document.getElementById(cont_name+"txt_credit").value=""
         document.getElementById(cont_name+"txt_debit").value=""
         return
        }
        //alert(document.getElementById("cmb_bank").value)
       //anil
//       if (document.getElementById(cont_name+"cmb_accno").value==31000)
//       {
//       document.getElementById(cont_name+"hdn_add").value=document.getElementById(cont_name+"hdn_add").value+"!"+document.getElementById(cont_name+"cmb_accno").value+"/"+document.getElementById(cont_name+"cmb_accno").options[document.getElementById(cont_name+"cmb_accno").selectedIndex].text+"/"+document.getElementById(cont_name+"cmb_subdtl").options[document.getElementById(cont_name+"cmb_subdtl").selectedIndex].text+"~"+document.getElementById(cont_name+"txt_descr").value+"~"+document.getElementById(cont_name+"txt_debit").value+"~"+document.getElementById(cont_name+"txt_credit").value+"~"+document.getElementById("cmb_bank").value+"~"+document.getElementById("txt_cheqno").value+"~"+document.getElementById("txt_bankname").value+"~"+document.getElementById("dt_cmb_day").value+"/"+document.getElementById("dt_cmb_month").value+"/"+document.getElementById("dt_cmb_year").value+"~"+"~"
//        break;
//       }
//       else
//       {
        document.getElementById(cont_name+"hdn_add").value=document.getElementById(cont_name+"hdn_add").value+"!"+document.getElementById(cont_name+"cmb_accno").value+"/"+document.getElementById(cont_name+"cmb_accno").options[document.getElementById(cont_name+"cmb_accno").selectedIndex].text+"/"+document.getElementById("cmb_bank").options[document.getElementById("cmb_bank").selectedIndex].text +"~"+document.getElementById(cont_name+"txt_descr").value+"~"+Math.abs(document.getElementById(cont_name+"txt_debit").value)+"~"+Math.abs(document.getElementById(cont_name+"txt_credit").value)+"~"+document.getElementById("cmb_bank").value+"~"+document.getElementById("txt_cheqno").value+"~"+document.getElementById("txt_bankname").value+"~"+document.getElementById("dt_cmb_day").value+"/"+document.getElementById("dt_cmb_month").value+"/"+document.getElementById("dt_cmb_year").value+"~"+"~"
        break;
//       }
     case 1:
        if (document.getElementById("txt_cusname").value=="" )
        {
           alert("Customer Name Not Entered..Please Enter")
           document.getElementById("txt_cusname").focus()
           return
        }
         document.getElementById(cont_name+"hdn_add").value=document.getElementById(cont_name+"hdn_add").value+"!"+document.getElementById(cont_name+"cmb_accno").value+"/"+document.getElementById(cont_name+"cmb_accno").options[document.getElementById(cont_name+"cmb_accno").selectedIndex].text+"~"+document.getElementById(cont_name+"txt_descr").value+"~"+Math.abs(document.getElementById(cont_name+"txt_debit").value)+"~"+Math.abs(document.getElementById(cont_name+"txt_credit").value)+"~"+"~"+"~"+"~"+"~"+document.getElementById("txt_cusname").value+"~"
         break;
     case 3:
        var br_name=document.getElementById(cont_name+"cmb_accno").value.split("/")
        //alert(br_name)
        //alert(document.getElementById("cmb_subdtl").options[document.getElementById("cmb_subdtl").selectedIndex].text)
//        if (br_name[0]==31000)
//        {
            document.getElementById(cont_name+"hdn_add").value=document.getElementById(cont_name+"hdn_add").value+"!"+document.getElementById(cont_name+"cmb_accno").value+"/"+document.getElementById(cont_name+"cmb_accno").options[document.getElementById(cont_name+"cmb_accno").selectedIndex].text+"/"+document.getElementById("cmb_subdtl").options[document.getElementById("cmb_subdtl").selectedIndex].text+"~"+document.getElementById(cont_name+"txt_descr").value+"~"+Math.abs(document.getElementById(cont_name+"txt_debit").value)+"~"+Math.abs(document.getElementById(cont_name+"txt_credit").value)+"~"+document.getElementById("cmb_subdtl").value+"~"+"~"+"~"+"~"+"~"
            //alert(document.getElementById(cont_name+"hdn_add").value)
            break;
//        }
//        else
//        {
//            document.getElementById(cont_name+"hdn_add").value=document.getElementById(cont_name+"hdn_add").value+"!"+document.getElementById(cont_name+"cmb_accno").value+"/"+document.getElementById(cont_name+"cmb_accno").options[document.getElementById(cont_name+"cmb_accno").selectedIndex].text+"~"+document.getElementById(cont_name+"txt_descr").value+"~"+document.getElementById(cont_name+"txt_debit").value+"~"+document.getElementById(cont_name+"txt_credit").value+"~"+document.getElementById("cmb_subdtl").value+"~"+"~"+"~"+"~"+"~"
//            break;
//        }
    case 4:
         document.getElementById(cont_name+"hdn_add").value=document.getElementById(cont_name+"hdn_add").value+"!"+document.getElementById(cont_name+"cmb_accno").value+"/"+document.getElementById(cont_name+"cmb_accno").options[document.getElementById(cont_name+"cmb_accno").selectedIndex].text+"~"+document.getElementById(cont_name+"txt_descr").value+"~"+Math.abs(document.getElementById(cont_name+"txt_debit").value)+"~"+Math.abs(document.getElementById(cont_name+"txt_credit").value)+"~"+document.getElementById("cmb_custdtl").value+"~"+"~"+"~"+"~"+"~"  
         break;
     default:
         document.getElementById(cont_name+"hdn_add").value=document.getElementById(cont_name+"hdn_add").value+"!"+document.getElementById(cont_name+"cmb_accno").value+"/"+document.getElementById(cont_name+"cmb_accno").options[document.getElementById(cont_name+"cmb_accno").selectedIndex].text+"~"+document.getElementById(cont_name+"txt_descr").value+"~"+Math.abs(document.getElementById(cont_name+"txt_debit").value)+"~"+Math.abs(document.getElementById(cont_name+"txt_credit").value)+"~"+"~"+"~"+"~"+"~"+"~"
   }
  // alert(document.getElementById("hdn_add").value)
   show_trans()
   document.getElementById(cont_name+"txt_debit").value=""
   document.getElementById(cont_name+"txt_credit").value=""
   document.getElementById(cont_name+"cmb_accno").selectedIndex=0
   document.getElementById(cont_name+"pnl_display").innerHTML=""
   document.getElementById(cont_name+"cmb_accno").focus()
   
}
function descr_focus()
{
  document.getElementById(cont_name+"txt_descr").focus()
}

function db_adv_check()
{
  var tot_tr
  tot_tr = document.getElementById(cont_name+"hdn_add").value.split("!")
   if (tot_tr.length <= 1)
  {
     alert("You Have Not Entered Any Transaction")
     document.getElementById(cont_name+"hdn_add").value = ""
     return false;
  }
  var fi
  var fi1
  var ind_tr1
  var ind_tr
  var tot_cr
  var tot_db
  var accc_str
  var ho_sele
  ho_sele=0
  for (fi1 = 1;fi1<=(tot_tr.length- 1);fi1++)
  {
    ind_tr1 = tot_tr[fi1].split("~")
    //alert(ind_tr1[0])
    accc_str = ind_tr1[0].split("/")
    accc_str = ind_tr1[0].split("/")
//    if (accc_str[0]==31000)
//    {
//       ho_sele=1
//    }
    ho_sele=1
  }
  if (ho_sele==0)
  {
      alert("Branch is not selected")
      return  false
  }
  tot_cr=0.0
  tot_db=0.0
  tot_cr.toFixed(2)
  tot_db.toFixed(2)
  for (fi = 1;fi<=(tot_tr.length- 1);fi++)
  {
    ind_tr = tot_tr[fi].split("~")
     
     if (!isNaN(parseFloat(ind_tr[2])))
        tot_cr = (Math.round(tot_cr*100)/100) + (Math.round(ind_tr[2]*100)/100)
        //tot_cr = parseFloat(tot_cr) + parseFloat(ind_tr[2])
     if (!isNaN(parseFloat(ind_tr[3])))
      tot_db = (Math.round(tot_db*100)/100) + (Math.round(ind_tr[3]*100)/100)
      //tot_db = parseFloat(tot_db) + parseFloat(ind_tr[3])
      //alert(tot_cr)
      //alert(tot_db)
  }
  tot_db=Math.round(tot_db*100)/100
  tot_cr =Math.round(tot_cr*100)/100
  if (tot_cr != tot_db )
   {
    alert( "Credits and Debits are not equal " + tot_cr + "CR " + tot_db + "DB")
    return  false
   } 
   tot_db=parseFloat(formatNumber(parseFloat(tot_db,2),'','.','','',''))
   tot_cr=parseFloat(formatNumber(parseFloat(tot_cr,2),'','.','','',''))
   
   if (document.getElementById(cont_name+"txt_nar").value == "")
   {
    alert("Please Enter Narration")
    document.getElementById(cont_name+"txt_nar").focus()
    return false 
   }  
   //document.getElementById("hidbank").value=""
   //document.getElementById(cont_name+"txt_nar").value=""
   //document.f1.submit()
 }
function m_anil(from_vb)
{
alert(from_vb)
}