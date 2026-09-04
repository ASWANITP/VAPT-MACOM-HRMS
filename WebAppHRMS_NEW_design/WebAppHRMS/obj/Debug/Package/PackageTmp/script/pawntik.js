      
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
    voucher_head(firm_name,branch_name,table_value,time_v,date_v)
    return_to_enter()   
}
function voucher_head(firm_name,branch_name,trans_n,time_v,date_v)
{
//alert(trans_n)
    var r_trans=trans_n.split("~")
    alert(r_trans)
    var g_len=r_trans[17].length
    var it1=""
    var it2=""
    var it3=""
    var it4=""
    var name=""
    var pre=""
    name=r_trans[1].substr(1,r_trans[1].length-1)
    pre=r_trans[1].substr(0,1)
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
    var ser=""
    
    if(r_trans[21].substr(0,4)=="zero")
    {
        ser=""
    }
    else
    {
        ser=r_trans[21]
    }
    it1=r_trans[17].substr(0,25)
    if ((g_len-25)>0)
    {
      it2=r_trans[17].substr(25,25)
    }
    if((g_len-50)>0)
    {
      it3=r_trans[17].substr(50,25)
    }
    if ((g_len-75)>0)
    {
      it4=r_trans[17].substr(75,25)
    }
    
    
    
    var amt1=""
    var amt2=""
    var amt3=""
    var p_len=r_trans[20].length
    amt1=r_trans[20].substr(0,15)
    if ((p_len-15)>0)
    {
      amt2=r_trans[20].substr(15,35)
    }
    if((p_len-50)>0)
    {
      amt3=r_trans[20].substr(50,50)
    }
   
    voucher_str=String.fromCharCode(27,50) + String.fromCharCode(27) + 'M' + String.fromCharCode(27) + 'E'
    voucher_str=voucher_str+r_trans[18].lpad(65-r_trans[18].length,' ')
    voucher_str=voucher_str+String.fromCharCode(10)
	var fm_len=firm_name.length
	var bal_len=65-fm_len;
	voucher_str=voucher_str+ (firm_name.lpad(parseInt((firm_name.length+(bal_len/2)),10),' ')).rpad((parseInt((bal_len/2)-10,10)),' ') + ' '
	voucher_str=voucher_str+String.fromCharCode(27) + 'P' + String.fromCharCode(27) + 'F'+ String.fromCharCode(15)  + 'E'
	voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)
	voucher_str=voucher_str+String.fromCharCode(9)+String.fromCharCode(9)
	voucher_str=voucher_str+r_trans[12].lpad(22+(7-r_trans[0].length),' ')
	voucher_str=voucher_str+"Scheme: ".lpad(26-r_trans[0].length,' ')+ r_trans[13].lpad(5-r_trans[13].length,' ')+String.fromCharCode(9)+ date_v.lpad(20,' ')
	voucher_str=voucher_str+String.fromCharCode(10)
	voucher_str=voucher_str+"Phone: ".lpad(31,' ')+ r_trans[19].lpad(17,' ') +time_v.lpad(20,' ')
	voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)
	var c_name=name.lpad(20,' ')+ ' '+ 'Ref.No. '+r_trans[0]
	voucher_str=voucher_str+c_name+'Cash_ID '.lpad(73-c_name.length,' ')+r_trans[23]
	voucher_str=voucher_str+String.fromCharCode(10)
	var h_name=r_trans[2].lpad(17+r_trans[2].length,' ')+' '+ r_trans[5].lpad(10+(7-r_trans[5].length)+r_trans[5].length,' ')
	voucher_str=voucher_str+h_name+r_trans[6].lpad(65-h_name.length,' ')+' '+String.fromCharCode(9)+r_trans[7]+' '+' Grams'
	voucher_str=voucher_str+String.fromCharCode(10) 
	var w_name=r_trans[3].lpad(17+r_trans[3].length,' ')
	voucher_str=voucher_str+w_name
	voucher_str=voucher_str+String.fromCharCode(10)
	var a_name=r_trans[4].lpad(17+r_trans[4].length,' ')+' '+ 'POST' + ' '
	var b_name=a_name+r_trans[9].lpad(66-a_name.length,' ')+'    C.L.R '
	voucher_str=voucher_str+b_name+r_trans[8].lpad(73-b_name.length,' ')
	voucher_str=voucher_str+String.fromCharCode(10)
	
	voucher_str=voucher_str+r_trans[22].lpad(73,' ')+'%'
	voucher_str=voucher_str+String.fromCharCode(10)
	var d_name=""
	if(ser=="")
	{
	d_name=it1.lpad(10+it1.length,' ')
	voucher_str=voucher_str+d_name
	}
	else 
	{
	d_name=it1.lpad(10+it1.length,' ')+'Ser. Chrg: '.lpad(43-it1.length,' ')
	voucher_str=voucher_str+d_name+ser+' '.lpad(55-d_name.length+r_trans[14].length,' ')+'%'
	}
	voucher_str=voucher_str+String.fromCharCode(10)
	voucher_str=voucher_str+it2.lpad(10+it2.length,' ')+r_trans[11].lpad(56-it2.length,' ')+'('+amt1
	voucher_str=voucher_str+String.fromCharCode(10)
	if(amt3=="")
	{
	voucher_str=voucher_str+it3.lpad(10+it3.length,' ')+' '.rpad(45,' ')+amt2+')'
	voucher_str=voucher_str+String.fromCharCode(10)	
	voucher_str=voucher_str+it4.lpad(10+it4.length,' ')
	}
	else
	{
	voucher_str=voucher_str+it3.lpad(10+it3.length,' ')+' '.rpad(45,' ')+amt2
	voucher_str=voucher_str+String.fromCharCode(10)
	voucher_str=voucher_str+it4.lpad(10+it4.length,' ')+' '.rpad(45,' ')+amt3+')'
	}
	voucher_str=voucher_str+String.fromCharCode(10)
	voucher_str=voucher_str+'Loan Duration :'.lpad(45,' ')+r_trans[15]+' '+'Days ,OD Int @'+ r_trans[16]+ '%'
	voucher_str=voucher_str+String.fromCharCode(10)
	voucher_str=voucher_str+String.fromCharCode(27)+'@'
	voucher_printing_end(voucher_str,1,'\\\\10.0.26.2\\pledge')
	//voucher_printing_end(voucher_str,1,"\\\\10.0.9.14\\anil")      
} 
function voucher_printing_end(input,no_voc,printer_data)
{
    voucher_file_creater(input,no_voc,printer_data)
    voucher_printer("C:\\motta_voucher" + file_temp[0] + no_voc +".bat")
}
function voucher_file_creater(input_str,no_voc,printer_data)
{
    try
    {  
    	var ax_ptr=new ActiveXObject("Scripting.FileSystemObject");
	    var file_ptr=ax_ptr.OpenTextFile("C:\\motta_voucher" + file_temp[0] + no_voc +".txt",2,true,0);
	    file_ptr.write(input_str);
	    file_ptr.close();
	    var inp;
	     
	    if (system_ip==' ' && branch_id_vouch==217)
	    {
	        alert("Contact IT For Printing Solution")
	    }
	    else
	    {    
	        if(branch_id_vouch==0 || branch_id_vouch==26 )
	        {	            
	           //inp="type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >lpt1"
	           //inp= "type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\"+system_ip+ "\\" + printer_name + "" 
	           inp= "type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >"+printer_data 
	            
	        }
	        else
	        { 
                inp="type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >lpt1"
//                inp="type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\10.0.0.110\\\\Epson"
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
function Start_pawn_printing()
{
vouch('test')
}
