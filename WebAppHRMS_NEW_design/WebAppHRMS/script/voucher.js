
// JScript File
    var tot_c=0,tot_d=0
    var narr_full,cash_id,tot_voch_glob,vstrlen
    var fso = new ActiveXObject("Scripting.FileSystemObject");
    var tem_filname = fso.GetTempName();
    var file_temp=tem_filname.split(".") 
    
////function fdp(n,d)
////    {
////	var xx = n.indexOf('.')
////	var l = n.length
////	var zstr = '0000000000000000000000'
////	var theInt = ''
////	var theFrac = ''
////	var theNo = ''
////	rfac = ''
////	rfacx = 0
////	nx = 0
////	var xt = parseInt(d) + 1
////	var rstr = '' + zstr.substring(1,xt)
////	var rfac = '.' + rstr + '5'
////	var rfacx = parseFloat(rfac)
////	if (xx == -1 ) 	{    // No fraction
////		theFrac = zstr
////		theInt = "" + n
////	}
////	else if (xx == 0) {
////		theInt = '0'
////		nx = 0 + parseFloat(n) + parseFloat(rfacx)
////		n = nx + zstr
////		theFrac = '' + n.substring(1, n.length)
////	}
////	else {
////		theInt = n.substring(0,xx)
////		nx = parseFloat(n) + rfacx
////		n = '' + nx + zstr
////		theFrac = '' + n.substring(xx+1,xx + 1 + parseInt(d))
////		var astr = 'd = ' + d
////	}
////	theFrac = theFrac.substring(0,parseInt(d))
////	var ii = 0
////	theNo = theInt + '.' + theFrac
////	return theNo
////}
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
    var vouch_str,vouch_str1
    if(flag==1)
    {
        vouch_str1=table_value.split("@")
        var k
        var firm_name1,branch_name1,trans_n1
        firm_name1=firm_name.split("@")
        branch_name1=branch_name.split("@")
        trans_n1=branch_name.split("@")
        for(k=0;k<vouch_str1.length;k++)
        {
            vouch_str=vouch_str1[k].split("!")
            var no_voch,voch_next=0
            if(vouch_str.length>8)
            {
                for(no_voch=1;no_voch<Math.ceil((vouch_str.length-1)/8)+1;no_voch++)
                {
                        voucher_head(firm_name1[k],branch_name1[k],trans_n1[k],time_v,date_v)
                        if(no_voch==1)
                        {
                            voch_next=0
                        }
                        else
                        {
                           voch_next=8+no_voch 
                        }
                        voucher_table_pinting(vouch_str1[k],no_voch,Math.ceil((vouch_str.length-1)/8))
                }                       
            }
            else
            {
               voucher_head(firm_name1[k],branch_name1[k],trans_n1[k],time_v,date_v)
               voucher_table_pinting(vouch_str,1,1)          
            }  
        }
        return_to_enter()  
    }
    else
    {    
        vouch_str=table_value.split("!")  
        var no_voch,voch_next=0
        vstrlen= vouch_str.length 
        if(vouch_str.length>8)
        {
            for(no_voch=1;no_voch<Math.ceil((vouch_str.length-1)/8)+1;no_voch++)
            {
                voucher_head(firm_name,branch_name,trans_n,time_v,date_v)
                if(no_voch==1)
                {
                    voch_next=0
                }
                else
                {
                   voch_next=8+no_voch 
                }
                if(no_voch==Math.ceil(vouch_str.length/8))
                {
                //alert("Motta")
                voucher_table_pinting(vouch_str,no_voch,Math.ceil((vouch_str.length-1)/8))
                }
                else
                {
                voucher_table_pinting(vouch_str,no_voch,Math.ceil((vouch_str.length-1)/8))
                }
            }
            
               return_to_enter() 
        }
        else
        {       
            voucher_head(firm_name,branch_name,trans_n,time_v,date_v)
            voucher_table_pinting(vouch_str,1,1)
            return_to_enter()
        }
     }
}
function voucher_head(firm_name,branch_name,trans_n,time_v,date_v)
{    
    var r_trans=trans_n.split("~")   
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=String.fromCharCode(27,67,3.9) + String.fromCharCode(27) + 'M' +String.fromCharCode(27) + 'W1' + String.fromCharCode(27) + 'E'
	if(firm_id==1)
	{
	   
	}
	else
	{
	    var fm_len=firm_name.length
	    var bal_len=80-fm_len;	    
	    voucher_str=voucher_str+ (firm_name.lpad(parseInt((bal_len/2)+10,10),' ')).rpad((parseInt((bal_len/2)-10,10)),' ') + ' '
	}
	
	voucher_str=voucher_str+String.fromCharCode(27) + 'M' +String.fromCharCode(27) + 'W0' + String.fromCharCode(27) + 'F'
	voucher_str=voucher_str+String.fromCharCode(10)
	voucher_str=voucher_str+String.fromCharCode(10)	
	voucher_str=voucher_str+ String.fromCharCode(9)+ branch_name +String.fromCharCode(9)+ String.fromCharCode(9)+ String.fromCharCode(9)+String.fromCharCode(9)+ r_trans[0] +String.fromCharCode(9)+ String.fromCharCode(9)+ time_v +String.fromCharCode(9)+ date_v
	voucher_str=voucher_str+String.fromCharCode(10)
	voucher_str=voucher_str+String.fromCharCode(10)
	voucher_str=voucher_str+String.fromCharCode(10)
	voucher_str=voucher_str+String.fromCharCode(10)

}

function voucher_table_pinting(vouch_str,no_voc,max)
{              
        var tr_lim,for_lim
        var tr_no,start
        var count=0
        start=8*(no_voc-1)
        tr_lim=start+8
            if(tr_lim>vouch_str.length)
            {
               for_lim=vouch_str.length
            }
            else
            {
                if(no_voc==max)
                {
                    for_lim=vouch_str.length  
                }
                else
                {
                    for_lim=tr_lim
                }
            
            }
           var ctot=0
           var dtot=0       
        if(no_voc==max)
        {
        for_lim=for_lim-1;
        }       
        for(tr_no=start+1;tr_no<for_lim+1;tr_no++)
	    {	           
	            var s_tr=vouch_str[tr_no].split("~")	          
	            var p1_des=s_tr[0].split("/")	           
	            var new_des=""
	            if (p1_des[1]==3 || p1_des[1]==2)
	            {                 
                        new_des=p1_des[3]+'    ('+s_tr[1] + ')'
	            }
	            else
	            {
	               new_des=p1_des[2]+'    ('+s_tr[1]+')'
	            }	           	          
	            if(s_tr[3]=="")
	            {	            
	                voucher_str=voucher_str+String.fromCharCode(27,15)	           
	                voucher_str=voucher_str+p1_des[0].lpad(7,' ') + '     '+new_des.rpad(75,' ') +s_tr[2].lpad(27,' ') 
	                voucher_str=voucher_str+String.fromCharCode(10)
	                dtot=dtot+ parseFloat(s_tr[2])  
	            }
	            else
	            {	            
	                voucher_str=voucher_str+String.fromCharCode(27,15)	           
	                voucher_str=voucher_str+ p1_des[0].lpad(7,' ') +'     '+ new_des.rpad(100,' ') + s_tr[3].lpad(27,' ')  
	                voucher_str=voucher_str+String.fromCharCode(10)
	                ctot=ctot+ parseFloat(s_tr[3]) 
	            }
	            count=count+1
        }
        voucher_str=voucher_str+String.fromCharCode(18)      
        if(count==2)
        {
            count+=1;
            voucher_str=voucher_str+String.fromCharCode(10)
        }
        if((count)<8)
        {        
            for(exl=count;exl<8;exl++)
            {
                voucher_str=voucher_str+String.fromCharCode(10)
            }
        }
        tot_c+=ctot;
	    tot_d+=dtot;
	    tot_voch_glob=no_voc
	    narr_full=nara_all
	    if(no_voc==max)
	    {
	        print_footer(narr_full,tot_c,tot_d,cash_id,no_voc)
	    }
	    else
	    {
	        voucher_printing(voucher_str,no_voc)
	    }	    	    
}
function print_footer_end(nar,tot_c,tot_d,key_cid,no_voc)
{
	    voucher_printing(voucher_str,no_voc)
}
function print_footer(nar,tot_c,tot_d,key_cid,no_voc)
{       
	    if (cash_id==0 )
	    {
	        voucher_str=voucher_str+String.fromCharCode(10)
	    }
	    else
	    {
	        voucher_str=voucher_str+String.fromCharCode(27,69)+String.fromCharCode(9)+ "Cash Id=" + cash_id + String.fromCharCode(27,70)+ String.fromCharCode(10)
	    }
	    var narr1,narr2
	    narr1=nar.substr(0,40)
	    narr2=nar.substr(40,80)	 
	    voucher_str=voucher_str+String.fromCharCode(9)+String.fromCharCode(9)+ narr1 + String.fromCharCode(10)
	    voucher_str=voucher_str+String.fromCharCode(9)+String.fromCharCode(9)+ narr2 + String.fromCharCode(10)
	    voucher_str=voucher_str+String.fromCharCode(10)	    
	    voucher_str=voucher_str+String.fromCharCode(10)
	    voucher_str=voucher_str+ String.fromCharCode(27,69)+ tot_d.toString().lpad(74,' ') +tot_c.toString().lpad(16,' ') + String.fromCharCode(27,70)
	    voucher_str=voucher_str+String.fromCharCode(12)+String.fromCharCode(27)+'@'
	    voucher_str=voucher_str+String.fromCharCode(10)
	    voucher_str=voucher_str+String.fromCharCode(10)
	    voucher_str=voucher_str+String.fromCharCode(10)	    
	    voucher_printing_end(voucher_str,no_voc)
}
function voucher_printing(input,no_voc)
{                      
       input+=String.fromCharCode(10)+String.fromCharCode(10)+String.fromCharCode(10)+String.fromCharCode(10)
       input+=String.fromCharCode(10)+String.fromCharCode(10)+String.fromCharCode(10)+String.fromCharCode(10)
       input+=String.fromCharCode(10)+String.fromCharCode(10)
       input+=String.fromCharCode(18)
       voucher_file_creater(input,no_voc)
       voucher_printer("C:\\motta_voucher" + file_temp[0] + no_voc +".bat")	   	   
}
function voucher_printing_end(input,no_voc)
{
    voucher_file_creater(input,no_voc)
    voucher_printer("C:\\motta_voucher" + file_temp[0] + no_voc +".bat")
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
function voucher_file_creater(input_str,no_voc)
{
    try
    {  
    	var ax_ptr=new ActiveXObject("Scripting.FileSystemObject");
    	//alert("voucher_file_creater()"+input_str)
	    var file_ptr=ax_ptr.OpenTextFile("C:\\motta_voucher" + file_temp[0] + no_voc +".txt",2,true,0);
	    file_ptr.write(input_str);
	    file_ptr.close();
	     //var inp="net use lpt1 /delete"
	    // var inp1="net use lpt1: \\\\10.0.0.104\\voucher /user:workgroup\\aniljose testing "  
	     //system_ip,ptinter_name,domain_name,user_name,password;
	    if (system_ip=='' && branch_id_vouch==0)
	    {
	        alert("Contact IT For Printing Solution")
	    }
	    else
	    {
	        //alert("net use "+port+": \\\\" + system_ip+ "\\" + printer_name + " /user:" + domain_name + "\\" + user_name +" "+ password )
	        //var inp1="net use "+port+": \\\\" + system_ip+ "\\" + printer_name + " /user:" + domain_name + "\\" + user_name +" "+ password  
	        if(system_ip!=' ')
	        {
	            
                var net;
                net = new ActiveXObject("WScript.Network");	
                //alert(file_temp[0])
                //net.AddPrinterConnection(          
	            var inp= "type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\"+system_ip+ "\\" + printer_name + "" 
	            //alert(inp)
	        }
	        else
	        { 
	            //alert("Motta")
	            var inp="type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >lpt1"
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
function file_delete()
{   
 for(vd=1;vd<=tot_voch_glob;vd++)
  {
     var myActiveXObject = new ActiveXObject("Scripting.FileSystemObject");
     var myActiveXObject1 = new ActiveXObject("Scripting.FileSystemObject");
     var file =  myActiveXObject.GetFile("C:\\motta_voucher" + file_temp[0] + vd +".txt");
     var file1 = myActiveXObject1.GetFile("C:\\motta_voucher" + file_temp[0] + vd +".bat");
     file.Delete();
     file1.Delete();
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
