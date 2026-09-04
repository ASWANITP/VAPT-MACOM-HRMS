//// JScript File
////variables From VB Page are :branch_id_vouch,nara_all,flag,firm_name,branch_name,table_value,
////                           :date_v,time_v,trans_n,cash_id
////                           :system_ip,ptinter_name,domain_name,user_name,password,port,firm_id

//   //var branch_id_vouch,nara_all,flag,firm_name,branch_name,table_value
//   // var date_v,time_v
//   // var system_ip,ptinter_name,domain_name,user_name,password,port,firm_id
//   
////   
//      // branch_id_vouch=217
////       nara_all= 'Anil Is Testing Deposit Rcpt'

////       firm_name='FINANCE(TAMIL NADU) PRIVATE LI'
////       branch_name='NAIKKANAL-TRICHUR'
////       table_value='1000007~0DINESH~DINESH~DINESH~DINESH~21212~3~90~800~50400~26~51900~0102170700700288~X~10~180~CHAIN-1-ghjfhjSTUD-2-ghhfj222CHAIN-1-ghjfhjSTUD-2-ghhfj333CHAIN-1-ghjfhjSTUD-2-ghhfj~KATOOR~ ~pl_word ~ sr_word ~in_word '
///
////       date_v='26-2-02-2007'
////       time_v='12:26:25'
////       system_ip='10.0.9.14'
////      printer_name='anil'
////      domain_name='dotnet'
////      user_name='aniljose'
////      password='mysis'
////      port='lpt1'
////       firm_id=7
//       
    var tot_c=0,tot_d=0
    var narr_full,tot_voch_glob,vstrlen
    var fso = new ActiveXObject("Scripting.FileSystemObject");
    var tem_filname = fso.GetTempName();
    var file_temp=tem_filname.split(".") 
    

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
String.prototype.rpad=function (num,cpad)
{
		var i;
		var a=this.split('');
		for(i=0;i<num-this.length;i++)
		{
			a.push(cpad)
		}
		return a.join('')
}   

var voucher_str
function system_info()
{	
	try
	{
		var ax = new ActiveXObject("WScript.Network");
	    document.write('User: ' + ax.UserName + "<br />");
	    document.write('Computer: ' + ax.ComputerName + '<br />');
		//document.write('Computer: ' + ax.ClientAddress + '<br />');
	}
	catch (e)
	{
		document.write('Permission to access computer name is denied' + '<br />');	
	}		
}
var narr=" Anil ";
function vouch(from_server)
{
//alert("vouch")
    voucher_head(firm_name,branch_name,table_value,time_v,date_v)
    return_to_enter()   
}

function vouch1(from_server)
{
    voucher_head2(firm_name,branch_name,table_value,time_v,date_v)
    return_to_enter()   
}

function voucher_head(firm_name,branch_name,trans_n,time_v,date_v)
{
    var trans=trans_n.split("!")
    var j=0;
    
    var cn=trans.length

 //         1          2 3 4       5             6        7               8         9            10          11               12      13     14    15      16       17 
   
//   0102170700700093~90~R~A~23-MAR-2006~23-MAR-2007~27-APR-2007~01021700000059~2AFSAL.P.H~S/O HAMZA~PUTHIYAVEETTIL  HOUSE~KATTOOR~2877629~50000~KATTOOR~680702~Trichur

//   0102170700700212~30~U~X~23-FEB-2007~25-MAR-2007~28-APR-2007~6500~01021700000030~2MUHAMMED KUTTY~S/O KADAR~MADATHIPARAMBIL HOUSE~POJANAM~2876694


for(j=1;j<=cn-2;j++)
    {

            var r_trans=trans[j].split("~")
            var name=""
            var pre=""
            name=r_trans[9].substr(1,r_trans[9].length-1)
            pre=r_trans[9].substr(0,1)
            if (pre=="0")
            {
                pre="Mr."
            }
            else if(pre=="1")
            {
                pre="Mrs."
            }
            else 
            {
                pre="Ms."
            }
            name=pre+name
              
            voucher_str=String.fromCharCode(27,78,66) 
            voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)
            var fm_len=firm_name.length
	        var bal_len=65-fm_len;
	        voucher_str=voucher_str+ (firm_name.lpad(parseInt((firm_name.length+(bal_len/2)),10),' ')).rpad((parseInt((bal_len/2)-10,10)),' ') + ' '
	        voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)
	        voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)+String.fromCharCode(10)+String.fromCharCode(10)
            voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)+String.fromCharCode(10)+String.fromCharCode(10)
	        voucher_str=voucher_str+String.fromCharCode(9)+String.fromCharCode(9)
	        voucher_str=voucher_str+'To'.rpad(1,' ')
	        voucher_str=voucher_str+String.fromCharCode(9)+String.fromCharCode(9)
	        voucher_str=voucher_str+String.fromCharCode(10)
	        voucher_str=voucher_str+String.fromCharCode(9)+String.fromCharCode(9)+'  '+name.rpad(25,' ')
        	
          if (r_trans[10]!="" )
          {
              voucher_str=voucher_str+String.fromCharCode(10)
              voucher_str=voucher_str+String.fromCharCode(9)+String.fromCharCode(9)
              voucher_str=voucher_str+'  '+r_trans[10].rpad(25,' ')
          }
          if (r_trans[11]!="" )
          {
                voucher_str=voucher_str+String.fromCharCode(10)
                voucher_str=voucher_str+String.fromCharCode(9)+String.fromCharCode(9)
                voucher_str=voucher_str+'  '+r_trans[11].rpad(25,' ')
          }
          if (r_trans[12]!="" )
          {
                voucher_str=voucher_str+String.fromCharCode(10)
                voucher_str=voucher_str+String.fromCharCode(9)+String.fromCharCode(9)
               // voucher_str=voucher_str+'  '+r_trans[12].rpad(25,' ')
                voucher_str=voucher_str+'  '+' P.O  '+r_trans[12].rpad(25,' ')
          }
          if (r_trans[15]!="" )
          {
                voucher_str=voucher_str+String.fromCharCode(10)
                voucher_str=voucher_str+String.fromCharCode(9)+String.fromCharCode(9)
                voucher_str=voucher_str+'  '+r_trans[15]
          } 
          
          if (r_trans[16]!="" )
          {
                voucher_str=voucher_str+'-'+r_trans[16]
          } 
          
          if(trans[0]=="1")
          {
              voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)+String.fromCharCode(10)
              voucher_str=voucher_str+date_v.lpad(35,' ')   
              voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)
              var a_name=r_trans[0].lpad(10,' ')+r_trans[4].lpad(30-r_trans[0].length,' ')
              voucher_str=voucher_str+a_name+r_trans[7].lpad(45-a_name.length,' ') 
              voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)+String.fromCharCode(10)
              voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)+String.fromCharCode(10)
              voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)
             // var dt1= date_v
              //var ndt=add_days(dt1,7)
             // alert(ndt)
              voucher_str=voucher_str+r_trans[17]    
          }
          if(trans[0]!="1")
          {
              voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)+String.fromCharCode(10)
              voucher_str=voucher_str+date_v.lpad(35,' ')   
              voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)
              var a_name=r_trans[0].lpad(10,' ')+r_trans[4].lpad(30-r_trans[0].length,' ')
              voucher_str=voucher_str+a_name+r_trans[7].lpad(45-a_name.length,' ') 
              voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)+String.fromCharCode(10)
              voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)+String.fromCharCode(10)
              voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)
//              var dt1= date_v
//              var ndt=add_days(dt1,7)
              voucher_str=voucher_str+r_trans[17]   
          }
          
         
          voucher_str=voucher_str+String.fromCharCode(10) 
          voucher_str=voucher_str+String.fromCharCode(27)+'@'
          voucher_printing_end(voucher_str,1)    
//          alert(voucher_str)                
      } 
}
  function add_days(date_in1,days)
  {
//      alert(date_in1)
//      alert(days)
      var myDate = new Date;
      var ret_date;
      var sp1=date_in1.split("-")
      myDate.setDate(parseInt(sp1[0],10)+parseInt(days,10));
      sp1[1]=c_mon_to_num(sp1[1])
      myDate.setMonth(parseInt(sp1[1])-parseInt(1));  // January = 0
      myDate.setFullYear(sp1[2]);
      ret_date=myDate.getDate() + '-' + c_mon_to_chr(parseInt(myDate.getMonth(),10)+parseInt(1,10)) + '-' + myDate.getFullYear()
      alert(ret_date)
      return (ret_date)
  }
function c_mon_to_chr(mon_num)
{
        var temp=mon_num;
	    if(temp==1)
        {
        temp='JAN';
        }
        else if( temp==2)
        {
           temp='FEB';
        }
        else if( temp==3)
        {
            temp='MAR';
        }
        else if(temp==4)
        {
            temp='APR';
        }
        else if(temp==5)
        {
            temp='MAY';
        }
        else if(temp==6)
        {
            temp='JUN';
        }
        else if(temp==7)
        {
            temp='JUL';
        }
        else if(temp==8)
        {
           temp='AUG' ;
        }
        else if( temp==9)
        {
           temp='SEP';
        }
        else if( temp==10)
        {
           temp='OCT';
        }
        else if(temp==11)
        {
            temp='NOV';
        }
        else if(temp==12)
        {
            temp='DEC';
        }
        return temp;
}
function c_mon_to_num(mon_chr)
{
var month=mon_chr.toUpperCase();
    if(month=='JAN')
            {
                month=1;
            }
            else if(month=='FEB')
            {
                month=2;
            }
            else if( month=='MAR')
            {
                month=3;
            }
            else if(month=='APR')
            {
                month=4;
            }
            else if(month=='MAY')
            {
                month=5;
            }
            else if(month=='JUN')
            {
                month=6;
            }
            else if(month=='JUL')
            {
                month=7;
            }
            else if(month=='AUG')
            {
                month=8;
            }
            else if(month=='SEP')
            {
                month=9;
            }
            else if(month=='OCT')
            {
                month=10;
            }
            else if(month=='NOV')
            {
                month=11;
            }
            else if(month=='DEC')
            {
                month=12;
            }
            return month;
}

function voucher_head2(firm_name,branch_name,trans_n,time_v,date_v)
{
    var voucher_str=""
    var trans=trans_n.split("!")
    var j=0;
    var cn=trans.length
    var i=0;
           
    voucher_str=voucher_str+'List of letters under UCP as on '.rpad(10,' ')+' '+Date()
    voucher_str=voucher_str+String.fromCharCode(27)+"E"+String.fromCharCode(27)+"M"
    voucher_str=voucher_str+String.fromCharCode(10)  
    voucher_str=voucher_str+'Ref. No. '.lpad(16,' ')+'Address'.lpad(20,' ')+'Remarks'.lpad(50,' ')
    voucher_str=voucher_str+String.fromCharCode(10)  
    voucher_str=voucher_str+String.fromCharCode(27)+"F"
    for(i=1;i<=92;i++)
    {
         voucher_str=voucher_str+String.fromCharCode(45)
    }
  
 //         1          2 3 4       5             6        7               8         9            10          11               12      13     14    15      16       17 
   
//   0102170700700093~90~R~A~23-MAR-2006~23-MAR-2007~27-APR-2007~01021700000059~2AFSAL.P.H~S/O HAMZA~PUTHIYAVEETTIL  HOUSE~KATTOOR~2877629~50000~KATTOOR~680702~Trichur


//     0102170700700212~30~U~X~23-FEB-2007~25-MAR-2007~28-APR-2007~6500~01021700000030~2MUHAMMED KUTTY~S/O KADAR~MADATHIPARAMBIL HOUSE~POJANAM~2876694
    var slno=0;
   
     for(j=1;j<cn-1;j++)
        {
            slno=slno+1
            var r_trans=trans[j].split("~")
            var name=""
            var pre=""
            name=r_trans[9].substr(1,r_trans[9].length-1)
            pre=r_trans[9].substr(0,1)
            if (pre=="0")
            {
                pre="Mr."
            }
            else if(pre=="1")
            {
                pre="Mrs."
            }
            else 
            {
                pre="Ms."
            }
            name=pre+name
            voucher_str=voucher_str+String.fromCharCode(10)
            voucher_str=voucher_str+r_trans[0].lpad(16,' ')+' '+name.lpad(25-r_trans[0].length,' ')     
            if (r_trans[10]!="" )
                  {
                      voucher_str=voucher_str+String.fromCharCode(10)
                      voucher_str=voucher_str+' '.lpad(17,' ')+r_trans[10]
                  }
                  if (r_trans[11]!="" )
                  {
                        voucher_str=voucher_str+String.fromCharCode(10)
                        voucher_str=voucher_str+' '.lpad(17,' ')+r_trans[11]
                  }
                  if (r_trans[12]!="" )
                  {
                        voucher_str=voucher_str+String.fromCharCode(10)
                        voucher_str=voucher_str+' '.lpad(17,' ')+r_trans[12]
                  }
                  if (r_trans[15]!="" )
                  {
                        voucher_str=voucher_str+String.fromCharCode(10)
                        voucher_str=voucher_str+' '.lpad(17,' ')+r_trans[15]+' P.O '
                  } 
                  
                  if (r_trans[16]!="" )
                  {
                        voucher_str=voucher_str+r_trans[16]
                  }         
             } 
    voucher_str=voucher_str+String.fromCharCode(10)        
    for(i=1;i<=92;i++)
    {
         voucher_str=voucher_str+String.fromCharCode(45)
    }
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+'Total Letters :  '.lpad(30,' ')+slno      
    voucher_str=voucher_str+String.fromCharCode(10) 
    voucher_str=voucher_str+String.fromCharCode(27)+'@'
    voucher_printing_end(voucher_str,1)    
//    alert(voucher_str)                        
}




 
function voucher_printing_end(input,no_voc)
{
    voucher_file_creater(input,no_voc)
    voucher_printer("C:\\motta_voucher" + file_temp[0] + no_voc +".bat")
}
function voucher_file_creater(input_str,no_voc)
{
    try
    {  
    	var ax_ptr=new ActiveXObject("Scripting.FileSystemObject");
//    	alert("voucher_file_creater()"+input_str)
	    var file_ptr=ax_ptr.OpenTextFile("C:\\motta_voucher" + file_temp[0] + no_voc +".txt",2,true,0);
	    file_ptr.write(input_str);
	    file_ptr.close();
	    var inp;
	    //var inp="net use lpt1 /delete"
	   // var inp1="net use lpt1: \\\\10.0.0.104\\voucher /user:workgroup\\aniljose testing "  
	    //system_ip,ptinter_name,domain_name,user_name,password;
	    
	    if (system_ip==' ' && branch_id_vouch==217)
	    {
	        alert("Contact IT For Printing Solution")
	    }
	    else
	    {    
//alert( )
	        //alert("net use "+port+": \\\\" + system_ip+ "\\" + printer_name + " /user:" + domain_name + "\\" + user_name +" "+ password )
	        //var inp1="net use "+port+": \\\\" + system_ip+ "\\" + printer_name + " /user:" + domain_name + "\\" + user_name +" "+ password  
	         //alert(branch_id_vouch)
	        if(branch_id_vouch==0 || branch_id_vouch==26 )
	        {	            
//	            inp= "type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\"+system_ip+ "\\" + printer_name + "" 
                inp= "type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\10.0.26.1\\voucher" 
//inp= "type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\10.0.9.14\\anil" 
	            
	        }
	        else
	        { 
//                inp="type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\10.0.9.14\\\\anil"
                inp="type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >lpt1"
	        } 
	    }	       	   
	    var file_bat=ax_ptr.OpenTextFile("C:\\motta_voucher" + file_temp[0] + no_voc +".bat",2,true,0);	   
	    file_bat.write(inp);
	    file_bat.close(); 
	    file_bat_print.close();
	}
	catch(e)
	{
	    alert('Permission to access this computer\'s file system is denied Please In form IT DotNet Section')
	    document.write('Permission to access computer\'s file system is denied Please In form IT' + '<br/>');
	}
}
function voucher_printer(file_name_plus_path)
{
	try
		{
			var launcher = new ActiveXObject("WScript.Shell");
			launcher.Run(file_name_plus_path);
		}
	catch(e)
		{
		    alert('Anil Need the Permission to access this computer to run my command Please In form EDP')
			document.write('Anil Need the Permission to access this computer to run my command Please In form EDP' + '<br/>');
		}
}
function file_delete()
{   
     var myActiveXObject = new ActiveXObject("Scripting.FileSystemObject");
     var myActiveXObject1 = new ActiveXObject("Scripting.FileSystemObject");
      var file =  myActiveXObject.GetFile("C:\\motta_voucher" + file_temp[0] + 1 +".txt");
     var file1 = myActiveXObject1.GetFile("C:\\motta_voucher" + file_temp[0] + 1 +".bat");
//      file.Delete();
//     file1.Delete();
}
function return_to_enter()
{
    try
    {
        alert("End Of Voucher")
        file_delete()
        window.navigate("../home.aspx")
    }
    catch(e)
    {
        alert("Voucher file deleted: "+ e)
    }
}
function Start_printing()
{
vouch('test')
}

function Start_ucp_printing()
{
vouch1('test')
}

// JScript File


