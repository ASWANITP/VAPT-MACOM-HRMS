var xmlHttp
var ctl
var completed=0
completed=1
    function show_district(str,fn_id,ctl_id)
    { 
        ctl=ctl_id
     
        var url="../Ajax/cust_fill.aspx?sid="+str+"&fun_id="+fn_id
        xmlHttp=GetXmlHttpObject(stateChanged_fill)
         //  alert(url)
       	xmlHttp.open("GET", url , true)
	    xmlHttp.send(null)
	} 
 //************************************************       
  /*  function show_cust(fn_id,ctl_id)
    { 
        ctl=ctl_id
        var url="../Ajax/cust_fill.aspx?fun_id="+fn_id
        xmlHttp=GetXmlHttpObject(stateChanged)
       	xmlHttp.open("GET", url , true)
	    xmlHttp.send(null)
	    
	}*/ 
	  
   //**********************************************
	function stateChanged_fill() 
	{ 
	   // alert(xmlHttp.readyState)
		if (xmlHttp.readyState==4 || xmlHttp.readyState=="complete")
		{ 
			    compleated=xmlHttp.readyState
			    str=xmlHttp.responseText
			    //alert(str)
			    var ar=new Array()
				var ar1
				ar=str.split("~")
				document.getElementById(ctl).options.length=0
				for(i=1;i<ar.length;i++)
				{
					ar1=ar[i].split("!")
					var option1=document.createElement("OPTION")
					option1.text=ar1[1]
					option1.value=ar1[0]
					document.getElementById(ctl).add(option1)
				}
		} 
	} 
	
	
	
	function GetXmlHttpObject(handler)
	{ 
		var objXmlHttp=null

		if (navigator.userAgent.indexOf("Opera")>=0)
		{
			alert("This example doesn't work in Opera") 
			return 
		}
		if (navigator.userAgent.indexOf("MSIE")>=0)
		{ 
			var strName="Msxml2.XMLHTTP"
			if (navigator.appVersion.indexOf("MSIE 5.5")>=0)
			{
				strName="Microsoft.XMLHTTP"
			} 
			try
			{ 
				objXmlHttp=new ActiveXObject(strName)
				objXmlHttp.onreadystatechange=handler 
				return objXmlHttp
			} 
			catch(e)
			{ 
				alert("Error. Scripting for ActiveX might be disabled") 
				return 
			} 
		} 
		if (navigator.userAgent.indexOf("Mozilla")>=0)
		{
			objXmlHttp=new XMLHttpRequest()
			objXmlHttp.onload=handler
			objXmlHttp.onerror=handler 
			return objXmlHttp
		}
	} 
	
/*function hidden()
{
	document.getElementById("hid_cust").value=document.getElementById("cmb_occu").value+"*"+document.getElementById("cmb_cust").value+"*"+document.getElementById("cmb_country").value
	//alert(document.getElementById("hid_cust").value)
}*/
//function for fill combo
	function show_pin()
		{
			var ss
			ss=document.getElementById("cmb_post").value
			document.getElementById("textbox1").value=ss
			//alert(ss)
			ss=ss.split("@")
			document.getElementById("txt_pin").value=ss[0]
			document.getElementById("hid_pinsr").value=ss[1]
		 }
		
