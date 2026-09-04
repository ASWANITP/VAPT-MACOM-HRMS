// JScript File
       
    var tot_c=0,tot_d=0
    var narr_full,tot_voch_glob,vstrlen
    var fso = new ActiveXObject("Scripting.FileSystemObject");
    var tem_filname = fso.GetTempName();
    var file_temp=tem_filname.split(".")
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
var voucher_str
function vouch(from_server)
{
    voucher_head(firm_name,branch_name,table_value,time_v,date_v)
    return_to_enter()   
    no_of_prints(2)
    return_to_enter()
    voucher_head3(firm_name,branch_name,table_value1,time_v,date_v)
    return_to_enter()
    voucher_head3(firm_name,branch_name,table_value1,time_v,date_v)
    return_to_enter()  
    window.navigate("../home.aspx")  
    
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
    var f_trans=trans_n.split("!")
    var r_trans1=f_trans[1].split("~")
    voucher_str=String.fromCharCode(27,70,30) + String.fromCharCode(27) + 'M' 
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
    voucher_str=voucher_str+"Customer Advice".lpad(40,' ')
    voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)
    voucher_str=voucher_str+' Name : '.lpad(1,' ')+r_trans1[4]+ date_v.lpad(33,' ')
    voucher_str=voucher_str+String.fromCharCode(10)
    for(i=1;i<=50;i++)
    {
         voucher_str=voucher_str+String.fromCharCode(45)
    }
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+'Receipt No.'.lpad(10,' ')+'Pledge No'.lpad(28-'Receipt No.'.length,' ')+'Amount'.lpad(33-('Pledge No'.length+'Receipt No.'.length),' ')
    voucher_str=voucher_str+String.fromCharCode(10)
    for(i=1;i<=50;i++)
    {
         voucher_str=voucher_str+String.fromCharCode(45)
    }
    var tot=0;
    for(i=1;i<=parseInt(f_trans[0],10);i++)
    {
        var r_trans=f_trans[i].split("~")
        voucher_str=voucher_str+String.fromCharCode(10)
        var w_name=r_trans[1].lpad(10-r_trans[1].length,' ')+' '+r_trans[0].lpad(28-r_trans[1].length,' ')+' '
	    voucher_str=voucher_str+w_name+r_trans[3].lpad(40-w_name.length,' ')
	    tot=tot+parseFloat(r_trans[3],10)
    }
    voucher_str=voucher_str+String.fromCharCode(10)
    for(i=1;i<=50;i++)
    {
         voucher_str=voucher_str+String.fromCharCode(45)
    }
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+'Total'.lpad(15,' ')+' '.lpad(20,' ')+tot
    voucher_str=voucher_str+String.fromCharCode(10)
    voucher_str=voucher_str+String.fromCharCode(27)+'@'
    voucher_printing_end(voucher_str,1,"\\\\10.0.26.3\\release")
//	voucher_printing_end(voucher_str,1,"10.0.26.1\voucher") 
//voucher_printing_end(voucher_str,1,"\\\\10.0.9.14\\anil")  

} 
function voucher_head2(firm_name,branch_name,trans_n,time_v,date_v)
{
//    table_value='4!0102170700700316~10176~46~15946~Mr.DINESH~15900!0102170700700308~10177~56~17156~Mr.SANAL~17100!0102170700700309~10178~56~17156~Mr.SANAL~17100!0102170700700310~10179~58~15958~Mr.DINESH~15900!'

    var f_trans=trans_n.split("!")
    var r_trans1=f_trans[1].split("~")
    var i=0;
    var fm_len=firm_name.length
    var bal_len=65-fm_len;
    var br_namel=branch_name.length;
	var br_bal=80-br_namel;	
    var j=0;
    voucher_str=String.fromCharCode(27,70,30)  
    for(j=1;j<=parseInt(f_trans[0],10);j++)
    {
        var r_trans=f_trans[j].split("~")            
        voucher_str=voucher_str+ String.fromCharCode(27) + 'M'+String.fromCharCode(10)
        voucher_str=voucher_str+ String.fromCharCode(27) + 'g'
        voucher_str=voucher_str+ (firm_name.lpad(parseInt((firm_name.length-(bal_len/2))-15,10),' ')).rpad((parseInt((bal_len/2)-15,10)),' ') + ' '
    	voucher_str=voucher_str+String.fromCharCode(10)
        voucher_str=voucher_str+branch_name.lpad(26,' ')
        voucher_str=voucher_str+String.fromCharCode(10)
        voucher_str=voucher_str+"Cash Receipt".lpad(26,' ')
        voucher_str=voucher_str+String.fromCharCode(10)
        voucher_str=voucher_str+' '.lpad(35,' ')+time_v
        voucher_str=voucher_str+String.fromCharCode(10)
        voucher_str=voucher_str+'No     : '.lpad(1,' ')+r_trans[1].lpad(10-r_trans[1].length,' ')+date_v.lpad(33,' ')
        voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)
        var a_name='Pl. No.: '.lpad(1,' ')+r_trans[0].lpad(10-r_trans[0].length,' ')+'Pl. Amount : '.lpad(22,' ')
        voucher_str=voucher_str+a_name+r_trans[5].lpad(35-a_name.length,' ')
        voucher_str=voucher_str+String.fromCharCode(10)
        voucher_str=voucher_str+'Name : '.lpad(1,' ')+r_trans[4]
        voucher_str=voucher_str+String.fromCharCode(10)
        for(i=1;i<=50;i++)
        {
             voucher_str=voucher_str+String.fromCharCode(45)
        }
        voucher_str=voucher_str+String.fromCharCode(10)
        
        var princ=parseFloat(r_trans[3],10)-parseFloat(r_trans[2],10);
        
        if(princ>0)
        {
            voucher_str=voucher_str+'Principle    :'.lpad(5,' ')+' '.lpad(21,' ')+princ
        }
        
        var interest=parseFloat(r_trans[2],10);
        if(interest>0)
        {
            voucher_str=voucher_str+String.fromCharCode(10)+'Interest     :'.lpad(5,' ')+' '.lpad(21+(r_trans[2].length+1),' ')+interest
        }
        voucher_str=voucher_str+String.fromCharCode(10)
        for(i=1;i<=50;i++)
        {
             voucher_str=voucher_str+String.fromCharCode(45)
        }
        voucher_str=voucher_str+String.fromCharCode(10)
        voucher_str=voucher_str+'Total'.lpad(9,' ')+' '.lpad(26-('Total'.length-r_trans[3].length),' ')+r_trans[3]
        voucher_str=voucher_str+String.fromCharCode(10)
        voucher_str=voucher_str+String.fromCharCode(27)+'@'
   }
   voucher_printing_end(voucher_str,1,"\\\\10.0.26.3\\release")
//   voucher_printing_end(voucher_str,1,"\\\\10.0.26.2\\pledge") 
//   voucher_printing_end(voucher_str,1,"\\\\10.0.9.14\\anil")   
  	                      
} 

function voucher_head3(firm_name,branch_name,trans_n,time_v,date_v)
{
    var r_trans=trans_n.split("~")
    var g_len=r_trans[16].length
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
        pre="Ms"
    }
    name=pre+name
    var ser=""
    
    if(r_trans[20].substr(0,4)=="zero")
    {
        ser=""
    }
    else
    {
        ser=r_trans[20]
    }
    it1=r_trans[16].substr(0,25)
    if ((g_len-25)>0)
    {
      it2=r_trans[16].substr(25,25)
    }
    if((g_len-50)>0)
    {
      it3=r_trans[16].substr(50,25)
    }
    if ((g_len-75)>0)
    {
      it4=r_trans[16].substr(75,25)
    }
    var amt1=""
    var amt2=""
    var amt3=""
    var p_len=r_trans[19].length
    amt1=r_trans[19].substr(0,15)
    if ((p_len-15)>0)
    {
      amt2=r_trans[19].substr(15,35)
    }
    if((p_len-50)>0)
    {
      amt3=r_trans[19].substr(50,50)
    }
   
   
//                    1         2           3           4          5     6   7  8  9   10  11  12    13           14 15 16
//table_value= 01021700000192~0AKHILA~ANANTHARAMAN~KILLIKURISSY~PATAMBI~4555~1~14~800~7800~28~8200~0102170700700375~Z~0~90~
//        17        18    19                          20                           21                  22               23
//CHAIN-1-kjhghghj~KATOOR~ ~Eight Thousand Two Hundred  Rupees and zero Paise~zero  and half~Twenty Eight and half~ 0102170700700375
    
 
    voucher_str=String.fromCharCode(27,59) + String.fromCharCode(27) + 'M' + String.fromCharCode(27) + 'E'
    voucher_str=voucher_str+r_trans[17].lpad(65-r_trans[17].length,' ')
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
	voucher_str=voucher_str+"Phone: ".lpad(31,' ')+ r_trans[18].lpad(17,' ') +time_v.lpad(20,' ')
	voucher_str=voucher_str+String.fromCharCode(10)+String.fromCharCode(10)
	var c_name=name.lpad(20,' ')+ ' '+ 'Ref.No. '+r_trans[0]
	voucher_str=voucher_str+c_name+'Cash_ID '.lpad(73-c_name.length,' ')+r_trans[22]
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
	
	voucher_str=voucher_str+r_trans[21].lpad(73,' ')+'%'
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
	voucher_str=voucher_str+'Loan Duration :'.lpad(45,' ')+r_trans[15]+' '+'Days'
	voucher_str=voucher_str+String.fromCharCode(10)
	voucher_str=voucher_str+String.fromCharCode(27)+'@'
	 voucher_printing_end(voucher_str,1,"\\\\10.0.26.2\\pledge") 
//	voucher_printing_end(voucher_str,1,"\\\\10.0.26.3\\release") 
//	voucher_printing_end(voucher_str,1,"\\\\10.0.9.14\\anil")   
//	alert(voucher_str) 
} 



 
function voucher_printing_end(input,no_voc,printer_data)
{
    voucher_file_creater(input,no_voc,printer_data)
    voucher_printer("C:\\motta_voucher" + file_temp[0] + no_voc +".bat")
}


function voucher_file_creater(input_str,no_voc,printer_data)
{
//        alert(printer_data)
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

            if(branch_id_vouch==0 || branch_id_vouch==26)
            {	            
                 //inp="type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >lpt1"
                //inp= "type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\"+system_ip+ "\\" + printer_name + "" 
                inp= "type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >"+printer_data
	            
            }
            else
            { 
//                inp="type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\10.0.9.14\\anil"
                inp="type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >lpt1"
//                  inp="type c:\\motta_voucher" + file_temp[0] + no_voc +".txt >\\\\10.0.0.110\\\\Epson"
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

function Start_printing()
{
//alert("Start_printing() : "+table_value+"jhgjhghj"+table_value1)
vouch('test')
}

// JScript File

