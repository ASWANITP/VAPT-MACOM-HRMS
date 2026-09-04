// JScript File

    var tot_c=0,tot_d=0;
    var narr_full,tot_voch_glob,vstrlen;
    var fso = new ActiveXObject("Scripting.FileSystemObject");
    var tem_filname = fso.GetTempName();
    var file_temp=tem_filname.split(".");
    var print_mode=0

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
	}
	catch (e)
	{
		document.write('Permission to access computer name is denied');	
	}		
}
var narr=" Anil ";
function vouch(from_server)
{
    voucher_head(firm_name,branch_name,table_value,time_v,date_v)
    return_to_enter()   
//    print_mode=1
//    no_of_prints(3)
//    return_to_enter()
//    window.navigate("../home.aspx") 
}

function no_of_prints(n)
{
    var k;
    for(k=0;k<n;k++)
    {
        voucher_head2(firm_name,branch_name,table_value,time_v,date_v);
    }

}

function voucher_head(firm_name,branch_name,trans_n,time_v,date_v)
{
 
    var r_trans1=trans_n.split("@")
    var f_trans=r_trans1[14].split("!")
    voucher_str=String.fromCharCode(27,67,30) + String.fromCharCode(27) + 'M' 
    voucher_str=voucher_str+String.fromCharCode(10)
    var i=0;
    var fm_len=firm_name.length
    var bal_len=65-fm_len;
    voucher_str=voucher_str+ (firm_name.lpad(parseInt((firm_name.length-(bal_len/2))-15,10),' ')).rpad((parseInt((bal_len/2)-15,10)),' ') + ' '
	var br_namel=branch_name.length;
	var br_bal=80-br_namel;	
	voucher_str=voucher_str+String.fromCharCode(10)
	voucher_str=voucher_str+ (branch_name.lpad(parseInt((br_bal/2),10),' ')).rpad((parseInt((br_bal/2),10)),' ') + ' '+ String.fromCharCode(9)+ String.fromCharCode(9)
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+"GL1 NOTE".lpad(25,' ')
//                  1        2       3        4  5    6     7   8   9 1011 12 13 14   15              16  17
//table_value='0102171005@sanitha@29-MAY-2007@12@8.4@7500@750@6300@28@0@0@6300@Z@1@!BANGLE-1 adaasdsd@800@456'
    voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)
    voucher_str=voucher_str+'Quatation No : '.lpad(20-('Quatation No : '.length),' ')+r_trans1[0].lpad(10,' ')+ r_trans1[2].lpad(15,' ')
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+' Name : '.lpad(7,' ')+r_trans1[1].lpad(20-(r_trans1[1].length),' ')+'Scheme : '.lpad(10,' ')+r_trans1[12]
    voucher_str=voucher_str+String.fromCharCode(10)
//    voucher_str=voucher_str+'Scheme'.lpad(10,' ')+r_trans1[12]
//    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+'Gross Wt : '.lpad(10,' ')+r_trans1[3].lpad(10,' ')+'Net Wt : '.lpad(10,' ')+r_trans1[4]
    voucher_str=voucher_str+String.fromCharCode(10)
//    voucher_str=voucher_str+'Netwt'.lpad(10,' ')+r_trans1[4]
//    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+'PlgValue : '.lpad(10,' ')+r_trans1[7].lpad(10,' ')
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+'Int Rt : '.lpad(9,' ')+r_trans1[8].lpad(5-(r_trans1[8].length),' ')+'SerCharge : '.lpad(14,' ')+r_trans1[9]
    voucher_str=voucher_str+String.fromCharCode(10)
//    voucher_str=voucher_str+'SerCharge'.lpad(10,' ')+r_trans1[9]
//    voucher_str=voucher_str+String.fromCharCode(10)
//    voucher_str=voucher_str+'Netwt'.lpad(10,' ')+r_trans1[4]
//    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+'TotalCount : '.lpad(10,' ')+r_trans1[13].lpad(10,' ')
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+'Items'.lpad(1,' ')+String.fromCharCode(10)
   var cnt= f_trans.length-1
   for(i=1;i<=parseInt(cnt,10);i++)
    {
    var g_len=f_trans[i].length
    var it1=""
    var it2=""
    var it3=""
    it1=f_trans[i].substr(0,40)
    voucher_str=voucher_str+it1.lpad(1,' ')
    voucher_str=voucher_str+String.fromCharCode(10)
    if ((g_len-40)>0)
    {
      it2=f_trans[i].substr(40,40)
      voucher_str=voucher_str+it2.lpad(1,' ')
    voucher_str=voucher_str+String.fromCharCode(10)
    }
    if((g_len-80)>0)
    {
      it3=f_trans[i].substr(80,40)
      voucher_str=voucher_str+it3.lpad(1,' ')
      voucher_str=voucher_str+String.fromCharCode(10)
    }    
   }
    
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+'Accepted by : '.lpad(15,' ')+r_trans1[16]
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+String.fromCharCode(27)+'@'
	voucher_printing_end(voucher_str,1) 
//alert(voucher_str)
} 




//function voucher_head2(firm_name,branch_name,trans_n,time_v,date_v)
//{
////    table_value='4!0102170700700316~10176~46~15946~Mr.DINESH~15900!0102170700700308~10177~56~17156~Mr.SANAL~17100!0102170700700309~10178~56~17156~Mr.SANAL~17100!0102170700700310~10179~58~15958~Mr.DINESH~15900!'

//    var f_trans=trans_n.split("!")
//    var r_trans1=f_trans[1].split("~")
//    var i=0;
//    var fm_len=firm_name.length
//    var bal_len=65-fm_len;
//    var br_namel=branch_name.length;
//	var br_bal=80-br_namel;	
//    var j=0;
//    voucher_str=String.fromCharCode(27,67,30)  
//    for(j=1;j<=parseInt(f_trans[0],10);j++)
//    {
//        var r_trans=f_trans[j].split("~")            
//        voucher_str=voucher_str+ String.fromCharCode(27) + 'M'+String.fromCharCode(10)
//        voucher_str=voucher_str+ String.fromCharCode(27) + 'g'
//        voucher_str=voucher_str+ (firm_name.lpad(parseInt((firm_name.length-(bal_len/2))-15,10),' ')).rpad((parseInt((bal_len/2)-15,10)),' ') + ' '
//    	voucher_str=voucher_str+String.fromCharCode(10)
//        voucher_str=voucher_str+branch_name.lpad(26,' ')
//        voucher_str=voucher_str+String.fromCharCode(10)
//        voucher_str=voucher_str+"Cash Receipt".lpad(26,' ')
//        voucher_str=voucher_str+String.fromCharCode(10)
//        voucher_str=voucher_str+' '.lpad(35,' ')+time_v
//        voucher_str=voucher_str+String.fromCharCode(10)
//        voucher_str=voucher_str+'No     : '.lpad(1,' ')+r_trans[1].lpad(10-r_trans[1].length,' ')+date_v.lpad(33,' ')
//        voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)
//        var a_name='Pl. No.: '.lpad(1,' ')+r_trans[0].lpad(10-r_trans[0].length,' ')+'Pl. Amount : '.lpad(22,' ')
//        voucher_str=voucher_str+a_name+r_trans[5].lpad(35-a_name.length,' ')
//    //                  1             2    3   4    5       6
//    //table_value='0102170700700316~10176~46~15946~Anjali~159400'
//    
//        voucher_str=voucher_str+String.fromCharCode(10)
//        voucher_str=voucher_str+'Name : '.lpad(1,' ')+r_trans[4]
//        voucher_str=voucher_str+String.fromCharCode(10)
//        for(i=1;i<=50;i++)
//        {
//             voucher_str=voucher_str+String.fromCharCode(45)
//        }
//        voucher_str=voucher_str+String.fromCharCode(10)
//        
//        var princ=parseFloat(r_trans[3],10)-parseFloat(r_trans[2],10);
//        
//        if(princ>0)
//        {
//            voucher_str=voucher_str+'Principle    :'.lpad(5,' ')+' '.lpad(21,' ')+princ
//        }
//        
//        var interest=parseFloat(r_trans[2],10);
//        if(interest>0)
//        {
//            voucher_str=voucher_str+String.fromCharCode(10)+'Interest     :'.lpad(5,' ')+' '.lpad(21+(r_trans[2].length+1),' ')+interest
//        }
//        voucher_str=voucher_str+String.fromCharCode(10)
//        for(i=1;i<=50;i++)
//        {
//             voucher_str=voucher_str+String.fromCharCode(45)
//        }
//        voucher_str=voucher_str+String.fromCharCode(10)
//        voucher_str=voucher_str+'Total'.lpad(9,' ')+' '.lpad(26-('Total'.length-r_trans[3].length),' ')+r_trans[3]
//        voucher_str=voucher_str+String.fromCharCode(10)
//        voucher_str=voucher_str+String.fromCharCode(27)+'@'
//        //alert(voucher_str)
//   }
//   
//   voucher_printing_end(voucher_str,1)  
////   alert(voucher_str)
//  	                      
//} 

function voucher_printing_end(input,no_voc)
{
    voucher_file_creater(input,no_voc)
    voucher_printer("C:\\motta_voucher" + file_temp[0] + no_voc +".bat")
}



function voucher_file_creater(input_str,no_voc)
{
   //alert(print_mode)
    if(print_mode==0)
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
    	    
	        if (system_ip==' ' && branch_id_vouch==217)
	        {
	            alert("Contact IT For Printing Solution")
	        }
	        else
	        {    

	            //alert("net use "+port+": \\\\" + system_ip+ "\\" + printer_name + " /user:" + domain_name + "\\" + user_name +" "+ password )
	            //var inp1="net use "+port+": \\\\" + system_ip+ "\\" + printer_name + " /user:" + domain_name + "\\" + user_name +" "+ password  
	             //alert(branch_id_vouch)
            if(branch_id_vouch==0 || branch_id_vouch==26 )
            {	            
                inp= "type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\"+system_ip+ "\\" + printer_name + "" 
	            
            }
            else
            { 
                inp="type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >lpt1"
//                inp="type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\10.0.9.14\\anil"
//                inp="type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\10.0.0.110\\\\Epson"
            }
            
	        var file_bat=ax_ptr.OpenTextFile("C:\\motta_voucher" + file_temp[0] + no_voc +".bat",2,true,0);	   
	        file_bat.write(inp);
	        file_bat.close(); 
	        file_bat_print.close(); 
	        }
	    }
        catch(e)
        {
            alert('Permission to access this computer\'s file system is denied Please In form IT DotNet Section')
            document.write('Permission to access computer\'s file system is denied Please In form IT' + '<br/>');
        }
	    
	 }
	 else
	 {
	    //alert("Anil Jose"+print_mode)
	    try
        {  
    	        var ax_ptr=new ActiveXObject("Scripting.FileSystemObject");
        //    	alert("voucher_file_creater()"+input_str)
	            var file_ptr=ax_ptr.OpenTextFile("C:\\motta_voucher" + file_temp[0] + no_voc +".txt",2,true,0);
	            //alert(input_str)
	            file_ptr.write(input_str);
	            file_ptr.close();
	            var inp;
	           if (system_ip1==' ' && branch_id_vouch==217)
	            {
	                alert("Contact IT For Printing Solution")
	            }
	            else
	            {    

	              if(branch_id_vouch==217 )
	                {	            
	                    inp= "type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\"+system_ip1+ "\\" + printer_name1 + "" 
        	            
	                }
	                else
	                { 
//	                      inp="type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\10.0.9.14\\\\anil"
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
      file.Delete();
     file1.Delete();
}
function return_to_enter()
{
    try
    {
        alert("End Of Voucher")
        file_delete();
//        cash_print(3);
    }
    catch(e)
    {
        alert("Voucher file deleted: "+ e)
    }
}
function Start_printing()
{
//alert("Start_printing() :  "+table_value)
vouch('test')
}




