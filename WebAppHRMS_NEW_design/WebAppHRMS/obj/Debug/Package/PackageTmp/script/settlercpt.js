// JScript File


    //temp   
//    var branch_id_vouch,nara_all,flag,firm_name,branch_name,table_value
//    var date_v,time_v
//    var system_ip,ptinter_name,domain_name,user_name,password,port,firm_id
//       branch_id_vouch=0
//       nara_all= 'Anil Is Testing Deposit Rcpt'
//       firm_name='FINANCE(TAMIL NADU) PRIVATE LI'
//       branch_name='NAIKKANAL-TRICHUR'
//       //                1      2     3      4       5        6    7         8                9            10         11        12         13      14     15                   16           17              18        19
//       table_value='9846759087~TD~287878714~22/02/07~22/02/07~12~9.00~MR: ANIL JOSE~010026000111414~MALIEKKAL HOUSE~22/02/08~10900.00~MANAPPADOM~697689~Descrption debenture~10,000.00~Ten thousand only~Balance amount~25836914736912'
//       date_v='26-2-02-2007'
//       time_v='12:26:25'
//       system_ip='10.0.9.14'
//       printer_name='voucher'
//       domain_name='dotnet'
//       user_name='Administrator'
//       password='DotNet2'
//       port='lpt1'
//       firm_id=7
   //temp   
       
   
                 
    var tot_c=0,tot_d=0
    var narr_full,tot_voch_glob,vstrlen
    var fso = new ActiveXObject("Scripting.FileSystemObject");
    var tem_filname = fso.GetTempName();
    var file_temp=tem_filname.split(".") 
    

String.prototype.lpad=function (num,cpad)
	{
//		alert(num)
//		alert('motta:'+cpad)
//		alert(this.length)
		var i;
		var a=this.split('');
		for(i=0;i<num-this.length;i++)
		{
			a.unshift(cpad)
			
		}
		//alert(a)
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
function rep_str(str,len)
{  
    var k,ret
    for(k=0;k<len;k++)
    {
    ret=ret+str
    }
    return ret;
}
var voucher_str
function system_info()
{	
	try
	{
		var ax = new ActiveXObject("WScript.Network");
	    document.write('User: ' + ax.UserName + "<br />");
	    document.write('Computer: ' + ax.ComputerName + '<br />');
		document.write('Computer: ' + ax.ClientAddress + '<br />');
	}
	catch (e)
	{
		document.write('Permission to access computer name is denied' + '<br />');	
	}		
}
var narr=" Anil ";
function vouch(from_server)
{
    //alert("Motta")
    voucher_head(firm_name,branch_name,table_value,time_v,date_v)
   // voucher_head2(firm_name,branch_name,table_value2,time_v,date_v)
    return_to_enter()   
}
function voucher_head(firm_name,branch_name,trans_n,time_v,date_v)
{    
    //alert(trans_n)
    var r_trans=trans_n.split("~")
    voucher_str=voucher_str+String.fromCharCode(10)                                                               
    voucher_str=String.fromCharCode(27,67,24)
    voucher_str=voucher_str+String.fromCharCode(27) + "M"      
    voucher_str=voucher_str+String.fromCharCode(27) + "M"+String.fromCharCode(27) + "W1"+String.fromCharCode(27) + "E"
    voucher_str=voucher_str+ r_trans[0].lpad(27,' ')
    voucher_str=voucher_str+String.fromCharCode(27) + "P"+String.fromCharCode(27) + "W0"+String.fromCharCode(27) + "F" 
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+branch_id_vouch.toString().lpad(12,' ')    
    voucher_str=voucher_str+time_v.lpad(((43-branch_id_vouch.length)+time_v.length),' ')
    voucher_str=voucher_str+date_v.lpad(((14-time_v.length)+date_v.length),' ')
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+String.fromCharCode(10)
    if(parseFloat(r_trans[1])>0)
    {         
         if(r_trans[2]==1)
         {
            voucher_str=voucher_str+'CASH ID :'.lpad(22,' ')    
            voucher_str=voucher_str+r_trans[3].lpad((4+r_trans[3].length),' ')
            voucher_str=voucher_str+String.fromCharCode(10)
            voucher_str=voucher_str+'CASH RECEIVED'.lpad(26,' ')
            voucher_str=voucher_str+r_trans[1].lpad((26+r_trans[1].length),' ')
         }
        else 
        {
            voucher_str=voucher_str+'CASH ID :'.lpad(22,' ')    
            voucher_str=voucher_str+r_trans[3].lpad((4+r_trans[3].length),' ')
            voucher_str=voucher_str+String.fromCharCode(10)
            voucher_str=voucher_str+'CASH PAID'.lpad(22,' ')
            voucher_str=voucher_str+r_trans[1].lpad((43+r_trans[1].length),' ')
        }
    }
    else
    {
        voucher_str=voucher_str+String.fromCharCode(10)
    }
    voucher_str=voucher_str+String.fromCharCode(10)
    if(parseFloat(r_trans[4])>0)
    {     
      if (r_trans[2]==1)
      {
        voucher_str=voucher_str+'CHEQ ID :'.lpad(13,' ')    
        voucher_str=voucher_str+r_trans[5].lpad((3+r_trans[5].length),' ')
        voucher_str=voucher_str+String.fromCharCode(10)
        voucher_str=voucher_str+'CHEQUE RECEIVED  '.lpad(26,' ')+r_trans[4]
        voucher_str=voucher_str+r_trans[4].lpad((26+r_trans[4].length),' ')
      } 
      else
      {
        voucher_str=voucher_str+'CHEQ ID :'.lpad(22,' ')    
        voucher_str=voucher_str+r_trans[5].lpad((4+r_trans[5].length),' ')
        voucher_str=voucher_str+String.fromCharCode(10)
        voucher_str=voucher_str+'CHEQUE PAID  '.lpad(26,' ')+r_trans[4]
        voucher_str=voucher_str+r_trans[4].lpad((43+r_trans[4].length),' ')     
      }
    }
    else
    {
        voucher_str=voucher_str+String.fromCharCode(10)
    }
    voucher_str=voucher_str+String.fromCharCode(10)
    if( r_trans[7]>0)
    {
        if(r_trans[2]==1)
        {
            voucher_str=voucher_str+'TFR ID :'.lpad(13,' ')    
            voucher_str=voucher_str+r_trans[8].lpad((3+r_trans[8].length),' ')
            voucher_str=voucher_str+String.fromCharCode(10)
            voucher_str=voucher_str+'TFRD FROM DEP. CTL A/C '.lpad(36,' ')+r_trans[7]
            voucher_str=voucher_str+r_trans[7].lpad((15+r_trans[7].length),' ')
        }
        else
        { 
            voucher_str=voucher_str+'TFR ID :'.lpad(22,' ')    
            voucher_str=voucher_str+r_trans[8].lpad((4+r_trans[8].length),' ')
            voucher_str=voucher_str+String.fromCharCode(10)
            voucher_str=voucher_str+'TFRD TO DEP. CTL A/C '.lpad(36,' ')+r_trans[7]
            voucher_str=voucher_str+r_trans[7].lpad((31+r_trans[7].length),' ')               
        }
    }
    else
    {
        voucher_str=voucher_str+String.fromCharCode(10)
    }
    if(r_trans[2]==1)
    {
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+'BEING AMOUNT SETTLED ON '.lpad(37,' ') 
    voucher_str=voucher_str+r_trans[10]+' NO: '+r_trans[11]
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+' FROM '.lpad(18,' ')+r_trans[12]                    
    }
    else
    {
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+'BEING AMOUNT SETTLED ON '.lpad(34,' ') 
    voucher_str=voucher_str+r_trans[10]+' NO: '+r_trans[11]
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+' TO '.lpad(17,' ')+r_trans[12]            
    }     
    //alert(voucher_str)
    voucher_str=voucher_str+String.fromCharCode(12)+String.fromCharCode(27)+'@' 
    voucher_printing_end(voucher_str,1)                                  		                      
} 

function voucher_file_creater(input_str,no_voc)
{
    try
    {  
    	var ax_ptr=new ActiveXObject("Scripting.FileSystemObject");
    	//alert("voucher_file_creater()"+input_str)
	    var file_ptr=ax_ptr.OpenTextFile("C:\\motta_voucher" + file_temp[0] + no_voc +".txt",2,true,0);
	    file_ptr.write(input_str);
	    file_ptr.close();
	    var inp;
	    //var inp="net use lpt1 /delete"
	   // var inp1="net use lpt1: \\\\10.0.0.104\\voucher /user:workgroup\\aniljose testing "  
	    //system_ip,ptinter_name,domain_name,user_name,password;
	    
	    if (system_ip==' ' && branch_id_vouch==0)
	    {
	        alert("Contact IT For Printing Solution")
	    }
	    else
	    {    
	        //alert("net use "+port+": \\\\" + system_ip+ "\\" + printer_name + " /user:" + domain_name + "\\" + user_name +" "+ password )
	        //var inp1="net use "+port+": \\\\" + system_ip+ "\\" + printer_name + " /user:" + domain_name + "\\" + user_name +" "+ password  
	         //alert(branch_id_vouch)
	         //alert(system_ip)
	         //alert(no_voc)
	         //alert(printer_name)
	         //alert() 
	        if(system_ip!=' ')
	        {	            
	            inp= "type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\"+system_ip+ "\\" + printer_name + "" 
	        // alert(inp)  
	        }
	        else
	        { 
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
	    alert('Deposit Permission to access this computer\'s file system is denied Please In form IT DotNet Section')
	    document.write('Permission to access computer\'s file system is denied Please In form IT' + '<br/>');
	}
}
function voucher_printer(file_name_plus_path)
{
	try
		{
			//alert("voucher_printer()")
			//var launcher1 = new ActiveXObject("WScript.Shell");
			//launcher1.Run("C:\\dotnet_print.bat");
			var launcher = new ActiveXObject("WScript.Shell");
			launcher.Run(file_name_plus_path);
		}
	catch(e)
		{
		    alert('Anil Need the Permission to access this computer to run my command Please In form IT')
			document.write('Anil Need the Permission to access this computer to run my command Please In form IT' + '<br/>');
		}
}
function file_delete()
{   
      var myActiveXObject = new ActiveXObject("Scripting.FileSystemObject");
     var myActiveXObject1 = new ActiveXObject("Scripting.FileSystemObject");
      var file =  myActiveXObject.GetFile("C:\\motta_voucher" + file_temp[0] + 1 +".txt");
     var file1 = myActiveXObject1.GetFile("C:\\motta_voucher" + file_temp[0] + 1 +".bat");
      file.Delete();
     file1.Delete();
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
alert("Start_printing() :  "+table_value)
vouch('test')
}


function voucher_printing_end(input,no_voc)
{

    voucher_file_creater(input,no_voc)
    voucher_printer("C:\\motta_voucher" + file_temp[0] + no_voc +".bat")
} 