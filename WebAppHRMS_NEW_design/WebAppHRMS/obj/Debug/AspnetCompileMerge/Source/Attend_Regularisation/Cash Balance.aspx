<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Cash Balance.aspx.vb" Inherits="WebAppHRMS.LFC_Cash_Balance_ea0da2792020" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" >
var cont = master_no.split("Txt")
function safe11()
{
 if(document.getElementById(cont[0]+"TxtSafe11").value != "")
    {  
       
       document.getElementById(cont[0]+"TxtSafe12").value = Math.abs(document.getElementById(cont[0]+"TxtSafe11").value) * Math.abs(1000)
       document.getElementById(cont[0]+"TxtSafe12").value = Math.abs(document.getElementById(cont[0]+"TxtSafe12").value).toFixed(2);
//       document.getElementById(cont[0]+"TxtTot1").value=Math.abs(document.getElementById(cont[0]+"TxtSafe12").value)+Math.abs(document.getElementById(cont[0]+"TxtHand12").value);
//       document.getElementById(cont[0]+"TxtTot1").value=Math.abs(document.getElementById(cont[0]+"TxtTot1").value).toFixed(2); 
       if (SafeTotal()==true )
      
       return false; 
    }
    else(document.getElementById(cont[0]+"TxtSafe11").value == "")
    {
      document.getElementById(cont[0]+"TxtSafe12").value="";
//      document.getElementById(cont[0]+"TxtTot1").value=Math.abs(document.getElementById(cont[0]+"TxtHand12").value).toFixed(2);
      if (SafeTotal()==true )
                  return false;     
    }
    
  
    
}

function safe21()
{
    if(document.getElementById(cont[0]+"TxtSafe21").value != "")
    {  document.getElementById(cont[0]+"TxtSafe22").value = Math.abs(document.getElementById(cont[0]+"TxtSafe21").value)* Math.abs(500)
       document.getElementById(cont[0]+"TxtSafe22").value = Math.abs(document.getElementById(cont[0]+"TxtSafe22").value).toFixed(2);
//       document.getElementById(cont[0]+"TxtTot2").value=Math.abs(document.getElementById(cont[0]+"TxtSafe22").value)+Math.abs(document.getElementById(cont[0]+"TxtHand22").value);
 //      document.getElementById(cont[0]+"TxtTot2").value=Math.abs(document.getElementById(cont[0]+"TxtTot2").value).toFixed(2);
       if (SafeTotal()==true )
     
          return false;  
    }
    else(document.getElementById(cont[0]+"TxtSafe21").value == "")
    { 
        document.getElementById(cont[0]+"TxtSafe22").value="";
//        document.getElementById(cont[0]+"TxtTot2").value=Math.abs(document.getElementById(cont[0]+"TxtHand22").value).toFixed(2);
        if (SafeTotal()==true )
       
          return false; 
    }
    
}

function safe31()
{
    if(document.getElementById(cont[0]+"TxtSafe31").value != "")
    {  document.getElementById(cont[0]+"TxtSafe32").value = Math.abs(document.getElementById(cont[0]+"TxtSafe31").value)* Math.abs(100)
       document.getElementById(cont[0]+"TxtSafe32").value = Math.abs(document.getElementById(cont[0]+"TxtSafe32").value).toFixed(2);
//       document.getElementById(cont[0]+"TxtTot3").value=Math.abs(document.getElementById(cont[0]+"TxtSafe32").value)+Math.abs(document.getElementById(cont[0]+"TxtHand32").value);
//       document.getElementById(cont[0]+"TxtTot3").value=Math.abs(document.getElementById(cont[0]+"TxtTot3").value).toFixed(2);
        if (SafeTotal()==true )
        
          return false;  
    }
    else(document.getElementById(cont[0]+"TxtSafe31").value == "")
    {document.getElementById(cont[0]+"TxtSafe32").value=""
//     document.getElementById(cont[0]+"TxtTot3").value=Math.abs(document.getElementById(cont[0]+"TxtHand32").value).toFixed(2);
        if (SafeTotal()==true )
  
          return false;  
    }
    
}

function safe41()
{
    if(document.getElementById(cont[0]+"TxtSafe41").value != "")
    {  document.getElementById(cont[0]+"TxtSafe42").value = Math.abs(document.getElementById(cont[0]+"TxtSafe41").value)* Math.abs(50)
       document.getElementById(cont[0]+"TxtSafe42").value = Math.abs(document.getElementById(cont[0]+"TxtSafe42").value).toFixed(2);
//       document.getElementById(cont[0]+"TxtTot4").value=Math.abs(document.getElementById(cont[0]+"TxtSafe42").value)+Math.abs(document.getElementById(cont[0]+"TxtHand42").value);
//       document.getElementById(cont[0]+"TxtTot4").value=Math.abs(document.getElementById(cont[0]+"TxtTot4").value).toFixed(2);
        if (SafeTotal()==true )
       
          return false;  
    }
    else(document.getElementById(cont[0]+"TxtSafe41").value == "")
    {
     document.getElementById(cont[0]+"TxtSafe42").value=""
//     document.getElementById(cont[0]+"TxtTot4").value=Math.abs(document.getElementById(cont[0]+"TxtHand42").value).toFixed(2);
             if (SafeTotal()==true )
       
          return false;  
    }
    
}

function safe51()
{
    if(document.getElementById(cont[0]+"TxtSafe51").value != "")
    {  document.getElementById(cont[0]+"TxtSafe52").value = Math.abs(document.getElementById(cont[0]+"TxtSafe51").value)* Math.abs(20)
       document.getElementById(cont[0]+"TxtSafe52").value = Math.abs(document.getElementById(cont[0]+"TxtSafe52").value).toFixed(2);
//       document.getElementById(cont[0]+"TxtTot5").value=Math.abs(document.getElementById(cont[0]+"TxtSafe52").value)+Math.abs(document.getElementById(cont[0]+"TxtHand52").value);
//       document.getElementById(cont[0]+"TxtTot5").value=Math.abs(document.getElementById(cont[0]+"TxtTot5").value).toFixed(2);
        if (SafeTotal()==true )
        
          return false; 
    }
    else(document.getElementById(cont[0]+"TxtSafe51").value == "")
    {
      document.getElementById(cont[0]+"TxtSafe52").value=""
//      document.getElementById(cont[0]+"TxtTot5").value=Math.abs(document.getElementById(cont[0]+"TxtHand52").value).toFixed(2);
              if (SafeTotal()==true )
         
          return false; 
    }
    
}


function safe61()
{
    if(document.getElementById(cont[0]+"TxtSafe61").value != "")
    {  document.getElementById(cont[0]+"TxtSafe62").value = Math.abs(document.getElementById(cont[0]+"TxtSafe61").value)* Math.abs(10)
       document.getElementById(cont[0]+"TxtSafe62").value = Math.abs(document.getElementById(cont[0]+"TxtSafe62").value).toFixed(2);
//       document.getElementById(cont[0]+"TxtTot6").value=Math.abs(document.getElementById(cont[0]+"TxtSafe62").value)+Math.abs(document.getElementById(cont[0]+"TxtHand62").value);
//       document.getElementById(cont[0]+"TxtTot6").value=Math.abs(document.getElementById(cont[0]+"TxtTot6").value).toFixed(2);
        if (SafeTotal()==true )
        
          return false; 
    }
    else(document.getElementById(cont[0]+"TxtSafe61").value == "")
    {
     document.getElementById(cont[0]+"TxtSafe62").value=""
//     document.getElementById(cont[0]+"TxtTot6").value=Math.abs(document.getElementById(cont[0]+"TxtHand62").value).toFixed(2);
             if (SafeTotal()==true )
         
          return false;  
    }
    
}




function safe71()
{
    if(document.getElementById(cont[0]+"TxtSafe71").value != "")
    {  document.getElementById(cont[0]+"TxtSafe72").value = Math.abs(document.getElementById(cont[0]+"TxtSafe71").value)* Math.abs(5)
       document.getElementById(cont[0]+"TxtSafe72").value = Math.abs(document.getElementById(cont[0]+"TxtSafe72").value).toFixed(2);
//       document.getElementById(cont[0]+"TxtTot7").value=Math.abs(document.getElementById(cont[0]+"TxtSafe72").value)+Math.abs(document.getElementById(cont[0]+"TxtHand72").value);
//       document.getElementById(cont[0]+"TxtTot7").value=Math.abs(document.getElementById(cont[0]+"TxtTot7").value).toFixed(2);
        if (SafeTotal()==true )
       
          return false;  
    }
    else(document.getElementById(cont[0]+"TxtSafe71").value == "")
    {
     document.getElementById(cont[0]+"TxtSafe72").value=""
//     document.getElementById(cont[0]+"TxtTot7").value=Math.abs(document.getElementById(cont[0]+"TxtHand72").value).toFixed(2);
             if (SafeTotal()==true )
     
          return false;  
    }
   
}


function safe81()
{
    if(document.getElementById(cont[0]+"TxtSafe81").value != "")
    {  document.getElementById(cont[0]+"TxtSafe82").value = Math.abs(document.getElementById(cont[0]+"TxtSafe81").value)* Math.abs(2)
       document.getElementById(cont[0]+"TxtSafe82").value = Math.abs(document.getElementById(cont[0]+"TxtSafe82").value).toFixed(2);
//      document.getElementById(cont[0]+"TxtTot8").value=Math.abs(document.getElementById(cont[0]+"TxtSafe82").value)+Math.abs(document.getElementById(cont[0]+"TxtHand82").value);
//       document.getElementById(cont[0]+"TxtTot8").value=Math.abs(document.getElementById(cont[0]+"TxtTot8").value).toFixed(2);
        if (SafeTotal()==true )
    
          return false; 
    }
    else(document.getElementById(cont[0]+"TxtSafe81").value == "")
    {
    document.getElementById(cont[0]+"TxtSafe82").value=""
//    document.getElementById(cont[0]+"TxtTot8").value=Math.abs(document.getElementById(cont[0]+"TxtHand82").value).toFixed(2);
            if (SafeTotal()==true )
         
          return false;  
    }
    
}

function safe91()
{
    if(document.getElementById(cont[0]+"TxtSafe91").value != "")
    {  document.getElementById(cont[0]+"TxtSafe92").value = Math.abs(document.getElementById(cont[0]+"TxtSafe91").value)* Math.abs(1)
       document.getElementById(cont[0]+"TxtSafe92").value = Math.abs(document.getElementById(cont[0]+"TxtSafe92").value).toFixed(2);
//       document.getElementById(cont[0]+"TxtTot9").value=Math.abs(document.getElementById(cont[0]+"TxtSafe92").value)+Math.abs(document.getElementById(cont[0]+"TxtHand92").value);
//       document.getElementById(cont[0]+"TxtTot9").value=Math.abs(document.getElementById(cont[0]+"TxtTot9").value).toFixed(2);
        if (SafeTotal()==true )
        
          return false;  
    }
    else(document.getElementById(cont[0]+"TxtSafe91").value == "")
    { document.getElementById(cont[0]+"TxtSafe92").value=""
//    document.getElementById(cont[0]+"TxtTot9").value=Math.abs(document.getElementById(cont[0]+"TxtHand92").value).toFixed(2);
            if (SafeTotal()==true )
       
          return false;  
    }
    
}


function hand11()
{
    if(document.getElementById(cont[0]+"TxtHand11").value != "")
    {  document.getElementById(cont[0]+"TxtHand12").value = Math.abs(document.getElementById(cont[0]+"TxtHand11").value)* Math.abs(1000);
       document.getElementById(cont[0]+"TxtHand12").value = Math.abs(document.getElementById(cont[0]+"TxtHand12").value).toFixed(2);
       document.getElementById(cont[0]+"TxtTot1").value=Math.abs(document.getElementById(cont[0]+"TxtSafe12").value)+Math.abs(document.getElementById(cont[0]+"TxtHand12").value);
       document.getElementById(cont[0]+"TxtTot1").value=Math.abs(document.getElementById(cont[0]+"TxtTot1").value).toFixed(2);
        if (HandTotal()==true )
        {GrandTotal()
          return false;  }
    }
    else(document.getElementById(cont[0]+"TxtHand11").value == "")
      {
        document.getElementById(cont[0]+"TxtHand12").value=""
        document.getElementById(cont[0]+"TxtTot1").value=Math.abs(document.getElementById(cont[0]+"TxtSafe12").value).toFixed(2);
                if (HandTotal()==true )
      {GrandTotal()
          return false;  }
      }
      
}


function hand21()
{
    if(document.getElementById(cont[0]+"TxtHand21").value != "")
    {  document.getElementById(cont[0]+"TxtHand22").value = Math.abs(document.getElementById(cont[0]+"TxtHand21").value)* Math.abs(500);
       document.getElementById(cont[0]+"TxtHand22").value = Math.abs(document.getElementById(cont[0]+"TxtHand22").value).toFixed(2);
       document.getElementById(cont[0]+"TxtTot2").value=Math.abs(document.getElementById(cont[0]+"TxtSafe22").value)+Math.abs(document.getElementById(cont[0]+"TxtHand22").value);
       document.getElementById(cont[0]+"TxtTot2").value=Math.abs(document.getElementById(cont[0]+"TxtTot2").value).toFixed(2);
        if (HandTotal()==true )
     {GrandTotal()
          return false;  }
    }
    else(document.getElementById(cont[0]+"TxtHand21").value == "")
      {
        document.getElementById(cont[0]+"TxtHand22").value=""
        document.getElementById(cont[0]+"TxtTot2").value=Math.abs(document.getElementById(cont[0]+"TxtSafe22").value).toFixed(2);
                        if (HandTotal()==true )
         {GrandTotal()
          return false;  }
      } 
       
}


function hand31()
{
    if(document.getElementById(cont[0]+"TxtHand31").value != "")
    {  document.getElementById(cont[0]+"TxtHand32").value = Math.abs(document.getElementById(cont[0]+"TxtHand31").value)* Math.abs(100);
       document.getElementById(cont[0]+"TxtHand32").value = Math.abs(document.getElementById(cont[0]+"TxtHand32").value).toFixed(2);
       document.getElementById(cont[0]+"TxtTot3").value=Math.abs(document.getElementById(cont[0]+"TxtSafe32").value)+Math.abs(document.getElementById(cont[0]+"TxtHand32").value);
       document.getElementById(cont[0]+"TxtTot3").value=Math.abs(document.getElementById(cont[0]+"TxtTot3").value).toFixed(2);
        if (HandTotal()==true )
        {GrandTotal()
          return false;  }
    }
    else(document.getElementById(cont[0]+"TxtHand31").value == "")
      {
        document.getElementById(cont[0]+"TxtHand32").value=""
        document.getElementById(cont[0]+"TxtTot3").value=Math.abs(document.getElementById(cont[0]+"TxtSafe32").value).toFixed(2);
      if (HandTotal()==true )
        {GrandTotal()
          return false;  }
      }  
}

function hand41()
{
    if(document.getElementById(cont[0]+"TxtHand41").value != "")
    {  document.getElementById(cont[0]+"TxtHand42").value = Math.abs(document.getElementById(cont[0]+"TxtHand41").value)* Math.abs(50);
       document.getElementById(cont[0]+"TxtHand42").value = Math.abs(document.getElementById(cont[0]+"TxtHand42").value).toFixed(2);
       document.getElementById(cont[0]+"TxtTot4").value=Math.abs(document.getElementById(cont[0]+"TxtSafe42").value)+Math.abs(document.getElementById(cont[0]+"TxtHand42").value);
       document.getElementById(cont[0]+"TxtTot4").value=Math.abs(document.getElementById(cont[0]+"TxtTot4").value).toFixed(2);
        if (HandTotal()==true )
      {GrandTotal()
          return false;  }
    }
    else(document.getElementById(cont[0]+"TxtHand41").value == "")
      {
        document.getElementById(cont[0]+"TxtHand42").value=""
        document.getElementById(cont[0]+"TxtTot4").value=Math.abs(document.getElementById(cont[0]+"TxtSafe42").value).toFixed(2);
        if (HandTotal()==true )
        {GrandTotal()
          return false;  }    
      }  
}



function hand51()
{
    if(document.getElementById(cont[0]+"TxtHand51").value != "")
    {  document.getElementById(cont[0]+"TxtHand52").value = Math.abs(document.getElementById(cont[0]+"TxtHand51").value)* Math.abs(20);
       document.getElementById(cont[0]+"TxtHand52").value = Math.abs(document.getElementById(cont[0]+"TxtHand52").value).toFixed(2);
       document.getElementById(cont[0]+"TxtTot5").value=Math.abs(document.getElementById(cont[0]+"TxtSafe52").value)+Math.abs(document.getElementById(cont[0]+"TxtHand52").value);
       document.getElementById(cont[0]+"TxtTot5").value=Math.abs(document.getElementById(cont[0]+"TxtTot5").value).toFixed(2);
        if (HandTotal()==true )
        {GrandTotal()
          return false;  }
    }
    else(document.getElementById(cont[0]+"TxtHand51").value == "")
      {
        document.getElementById(cont[0]+"TxtHand52").value=""
        document.getElementById(cont[0]+"TxtTot5").value=Math.abs(document.getElementById(cont[0]+"TxtSafe52").value).toFixed(2);
        if (HandTotal()==true )
         {GrandTotal()
          return false;  }      
      }  
}


function hand61()
{
    if(document.getElementById(cont[0]+"TxtHand61").value != "")
    {  document.getElementById(cont[0]+"TxtHand62").value = Math.abs(document.getElementById(cont[0]+"TxtHand61").value)* Math.abs(10);
       document.getElementById(cont[0]+"TxtHand62").value = Math.abs(document.getElementById(cont[0]+"TxtHand62").value).toFixed(2);
       document.getElementById(cont[0]+"TxtTot6").value=Math.abs(document.getElementById(cont[0]+"TxtSafe62").value)+Math.abs(document.getElementById(cont[0]+"TxtHand62").value);
       document.getElementById(cont[0]+"TxtTot6").value=Math.abs(document.getElementById(cont[0]+"TxtTot6").value).toFixed(2);
        if (HandTotal()==true )
        {GrandTotal()
          return false;  }
    }
    else(document.getElementById(cont[0]+"TxtHand61").value == "")
      {
        document.getElementById(cont[0]+"TxtHand62").value=""
        document.getElementById(cont[0]+"TxtTot6").value=Math.abs(document.getElementById(cont[0]+"TxtSafe62").value).toFixed(2);
                if (HandTotal()==true )
        {GrandTotal()
          return false;  }       
      }  
}

function hand71()
{
    if(document.getElementById(cont[0]+"TxtHand71").value != "")
    {  document.getElementById(cont[0]+"TxtHand72").value = Math.abs(document.getElementById(cont[0]+"TxtHand71").value)* Math.abs(5);
       document.getElementById(cont[0]+"TxtHand72").value = Math.abs(document.getElementById(cont[0]+"TxtHand72").value).toFixed(2);
       document.getElementById(cont[0]+"TxtTot7").value=Math.abs(document.getElementById(cont[0]+"TxtSafe72").value)+Math.abs(document.getElementById(cont[0]+"TxtHand72").value);
       document.getElementById(cont[0]+"TxtTot7").value=Math.abs(document.getElementById(cont[0]+"TxtTot7").value).toFixed(2);
        if (HandTotal()==true )
        {GrandTotal()
          return false;  }
    }
    else(document.getElementById(cont[0]+"TxtHand71").value == "")
      {
        document.getElementById(cont[0]+"TxtHand72").value=""
        document.getElementById(cont[0]+"TxtTot7").value=Math.abs(document.getElementById(cont[0]+"TxtSafe72").value).toFixed(2);
                if (HandTotal()==true )
      {GrandTotal()
          return false;  }        
      }  
}

function hand81()
{
    if(document.getElementById(cont[0]+"TxtHand81").value != "")
    {  document.getElementById(cont[0]+"TxtHand82").value = Math.abs(document.getElementById(cont[0]+"TxtHand81").value)* Math.abs(2);
       document.getElementById(cont[0]+"TxtHand82").value = Math.abs(document.getElementById(cont[0]+"TxtHand82").value).toFixed(2);
       document.getElementById(cont[0]+"TxtTot8").value=Math.abs(document.getElementById(cont[0]+"TxtSafe82").value)+Math.abs(document.getElementById(cont[0]+"TxtHand82").value);
       document.getElementById(cont[0]+"TxtTot8").value=Math.abs(document.getElementById(cont[0]+"TxtTot8").value).toFixed(2);
        if (HandTotal()==true )
        {GrandTotal()
          return false;  }
    }
    else(document.getElementById(cont[0]+"TxtHand81").value == "")
      {
        document.getElementById(cont[0]+"TxtHand82").value=""
        document.getElementById(cont[0]+"TxtTot8").value=Math.abs(document.getElementById(cont[0]+"TxtSafe82").value).toFixed(2);
                if (HandTotal()==true )
       {GrandTotal()
          return false;  }      
      }  
}


function hand91()
{
    if(document.getElementById(cont[0]+"TxtHand91").value != "")
    {  document.getElementById(cont[0]+"TxtHand92").value = Math.abs(document.getElementById(cont[0]+"TxtHand91").value)* Math.abs(1);
       document.getElementById(cont[0]+"TxtHand92").value = Math.abs(document.getElementById(cont[0]+"TxtHand92").value).toFixed(2);
       document.getElementById(cont[0]+"TxtTot9").value=Math.abs(document.getElementById(cont[0]+"TxtSafe92").value)+Math.abs(document.getElementById(cont[0]+"TxtHand92").value);
       document.getElementById(cont[0]+"TxtTot9").value=Math.abs(document.getElementById(cont[0]+"TxtTot9").value).toFixed(2);
        if (HandTotal()==true )
 {GrandTotal()
          return false;  }
    }
    else(document.getElementById(cont[0]+"TxtHand91").value == "")
      {
        document.getElementById(cont[0]+"TxtHand92").value=""
        document.getElementById(cont[0]+"TxtTot9").value=Math.abs(document.getElementById(cont[0]+"TxtSafe92").value).toFixed(2);
                if (HandTotal()==true )
         {GrandTotal()
          return false;  }       
      }  
 }

function Change()
{
    if(document.getElementById(cont[0]+"TxtChangeRs").value != "")
      { 
//      document.getElementById(cont[0]+"TxtChangeRs").value=Math.abs(document.getElementById(cont[0]+"TxtChangeRs").value).toFixed(2)
       if (isNaN(document.getElementById(cont[0]+"TxtChangeRs").value))
        {document.getElementById(cont[0]+"TxtChangeRs").value="0.00"}
       if (SafeTotal()==true )
        return false;   
      }
      if (document.getElementById(cont[0]+"TxtChangeRs").value == "")
      { 
       if (SafeTotal()==true )
        return false;   
      }
  }    
 
function CoinChange()
 
 {
    if(document.getElementById(cont[0]+"TxtChangeRs").value != "")
       {
        if (isNaN(document.getElementById(cont[0]+"TxtChangeRs").value))
         {document.getElementById(cont[0]+"TxtChangeRs").value="0.00"; }
        if (SafeTotal()==true )
        return false;   
      }
      if (document.getElementById(cont[0]+"TxtChangeRs").value == "")
      { 
       if (SafeTotal()==true )
        return false;   
      }
 }
      
function LateCash()
{
    if(document.getElementById(cont[0]+"TxtLateCash").value != "")
       {
        if (isNaN(document.getElementById(cont[0]+"TxtLateCash").value))
         {document.getElementById(cont[0]+"TxtLateCash").value="0.00"; }
        if (SafeTotal()==true )
        return false;   
      }
      if (document.getElementById(cont[0]+"TxtLateCash").value == "")
      { 
       if (SafeTotal()==true )
        return false;   
      }
 }
     
//   if (document.getElementById(cont[0]+"TxtHandChRs").value == "")
//      {
//        document.getElementById(cont[0]+"TxtTot10").value=Math.abs(document.getElementById(cont[0]+"TxtChangeRs").value).toFixed(2);
//       HandTotal()
//       SafeTotal()
//       GrandTotal()
//       return false; 
//      } 
//      
// if ( (document.getElementById(cont[0]+"TxtChangeRs").value != "") && (document.getElementById(cont[0]+"TxtHandChRs").value != "") )
//    {  document.getElementById(cont[0]+"TxtTot10").value=Math.abs(document.getElementById(cont[0]+"TxtChangeRs").value) + Math.abs(document.getElementById(cont[0]+"TxtHandChRs").value);
//       document.getElementById(cont[0]+"TxtTot10").value=Math.abs(document.getElementById(cont[0]+"TxtTot10").value).toFixed(2);
//       HandTotal()
//       SafeTotal()
//       GrandTotal()
//       return false; 
//    }

function SafeTotal()
{
 
  var Safe1=Math.abs(document.getElementById(cont[0]+"TxtSafe12").value);
  var Safe2=Math.abs(document.getElementById(cont[0]+"TxtSafe22").value);
  var Safe3=Math.abs(document.getElementById(cont[0]+"TxtSafe32").value);
  var Safe4=Math.abs(document.getElementById(cont[0]+"TxtSafe42").value);
  var Safe5=Math.abs(document.getElementById(cont[0]+"TxtSafe52").value);
  var Safe6=Math.abs(document.getElementById(cont[0]+"TxtSafe62").value);
  var Safe7=Math.abs(document.getElementById(cont[0]+"TxtSafe72").value);
  var Safe8=Math.abs(document.getElementById(cont[0]+"TxtSafe82").value);
  var Safe9=Math.abs(document.getElementById(cont[0]+"TxtSafe92").value);
  var Safe10=Math.abs(document.getElementById(cont[0]+"TxtChangeRs").value);
  var Safe11=Math.abs(document.getElementById(cont[0]+"TxtLateCash").value);
  document.getElementById(cont[0]+"TxtSafeTot").value=Safe1+Safe2+Safe3+Safe4+Safe5+Safe6+Safe7+Safe8+Safe9+Safe10+Safe11;
  document.getElementById(cont[0]+"TxtSafeTot").value=Math.abs(document.getElementById(cont[0]+"TxtSafeTot").value).toFixed(2);
  return true;
  
}

function HandTotal()
{
 
  var Hand1=Math.abs(document.getElementById(cont[0]+"TxtHand12").value);
  var Hand2=Math.abs(document.getElementById(cont[0]+"TxtHand22").value);
  var Hand3=Math.abs(document.getElementById(cont[0]+"TxtHand32").value);
  var Hand4=Math.abs(document.getElementById(cont[0]+"TxtHand42").value);
  var Hand5=Math.abs(document.getElementById(cont[0]+"TxtHand52").value);
  var Hand6=Math.abs(document.getElementById(cont[0]+"TxtHand62").value);
  var Hand7=Math.abs(document.getElementById(cont[0]+"TxtHand72").value);
  var Hand8=Math.abs(document.getElementById(cont[0]+"TxtHand82").value);
  var Hand9=Math.abs(document.getElementById(cont[0]+"TxtHand92").value);
  var Hand10=Math.abs(document.getElementById(cont[0]+"TxtHandChRs").value);
  document.getElementById(cont[0]+"TxtHandTot").value=Hand1+Hand2+Hand3+Hand4+Hand5+Hand6+Hand7+Hand8+Hand9+Hand10;
  document.getElementById(cont[0]+"TxtHandTot").value=Math.abs(document.getElementById(cont[0]+"TxtHandTot").value).toFixed(2);
  return true;
  
}


function GrandTotal()
{
 var safetotal=Math.abs(document.getElementById(cont[0]+"TxtSafeTot").value);
 var handtotal=Math.abs(document.getElementById(cont[0]+"TxtHandTot").value);
 document.getElementById(cont[0]+"TxtTot11").value=safetotal+handtotal;
 document.getElementById(cont[0]+"TxtTot11").value=Math.abs(document.getElementById(cont[0]+"TxtTot11").value).toFixed(2);
 return true
}

function Numberonly1(ctrl)
{
     if (isNaN(document.getElementById(cont[0]+ctrl).value)) 
     {
        document.getElementById(cont[0]+ctrl).value="";
        return false; 
     }
}


function Numberonlycash()
{
     if (isNaN(document.getElementById(cont[0]+"TxtCashbalance").value)) 
     {
        document.getElementById(cont[0]+"TxtCashbalance").value="";
        return false; 
     }
}

function ConfirmClick()
{
 var SafeTotal=document.getElementById(cont[0]+"TxtSafeTot").value;
 var ChangeCash=document.getElementById(cont[0]+"TxtChangeRs").value
  
    if (SafeTotal=="" || SafeTotal=="0.00")
   {
    alert("Enter Cash Position \n Details ..!!!")
    return false;
   }
   

if (document.getElementById(cont[0]+"TxtSafe11").value=="")
   {document.getElementById(cont[0]+"TxtSafe11").value=0;
   }
   if (document.getElementById(cont[0]+"TxtSafe21").value=="")
   {document.getElementById(cont[0]+"TxtSafe21").value=0;
   }

  if (document.getElementById(cont[0]+"TxtSafe31").value=="")
   {document.getElementById(cont[0]+"TxtSafe31").value=0;
   }
   
   if (document.getElementById(cont[0]+"TxtSafe41").value=="")
   {document.getElementById(cont[0]+"TxtSafe41").value=0;
   }
   
   if (document.getElementById(cont[0]+"TxtSafe51").value=="")
   {document.getElementById(cont[0]+"TxtSafe51").value=0;
   }
   
   if (document.getElementById(cont[0]+"TxtSafe61").value=="")
   {document.getElementById(cont[0]+"TxtSafe61").value=0;
   }
   
   if (document.getElementById(cont[0]+"TxtSafe71").value=="")
   {document.getElementById(cont[0]+"TxtSafe71").value=0;
   }
   
   if (document.getElementById(cont[0]+"TxtSafe81").value=="")
   {document.getElementById(cont[0]+"TxtSafe81").value=0;
   }
   
   if (document.getElementById(cont[0]+"TxtSafe91").value=="")
   {document.getElementById(cont[0]+"TxtSafe91").value=0;
   }
 if (document.getElementById(cont[0]+"TxtLateCash").value=="")
   {document.getElementById(cont[0]+"TxtLateCash").value=0;
   }
    
   
}

function btnExit_onclick() 
{ window.open('../home.aspx','_self'); }

function isNumberKey(event)
{
   
   var charcode = (event.which) ? event.which : event.keyCode
   if ((charcode>47 && charcode<58))
    { return true; }
    
    else               return false; 
} 
function isNumberKey1(event)
{
   
   var charcode = (event.which) ? event.which : event.keyCode
   if ((charcode==32))
    { return false; }
    
    else               return true; 
} 

function FixNumber(Control)
{
  document.getElementById(cont[0]+Control).value=Math.abs(document.getElementById(cont[0]+Control).value).toFixed(2);
  return false
}

</script>


    <table border="1" align="center" >
        <tr>
            <td colspan="4" style="height: 16px; text-align: center">
                <strong><span>ENTER ONLY CASHIER !!!</span></strong></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 16px; text-align: center;">
                <span style="font-size: 14pt"><strong>CASH POSITION</strong></span></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 7px; width: 113px;">
                <strong>Denomination </strong></td>
            <td style="width: 82px; height: 7px; text-align: left;">
                <strong>No.of&nbsp;Pieces </strong></td>
            <td style="width: 91px; height: 7px; text-align: center;">
                <strong> &nbsp; &nbsp; Rupees</strong></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 23px; text-align: right; width: 113px;">
                <strong id="c1">1000</strong></td>
            <td style="width: 82px; height: 23px">
                <asp:TextBox ID="TxtSafe11" runat="server" Width="85px" style="text-align: right" MaxLength="8"></asp:TextBox></td>
            <td style="width: 91px; height: 23px">
                <asp:TextBox ID="TxtSafe12" runat="server" ReadOnly="True" TabIndex="1" style="text-align: right" Font-Italic="False" Width="149px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 25px; text-align: right; width: 113px;">
                <strong id="c2">500</strong></td>
            <td style="width: 82px; height: 25px">
                <asp:TextBox ID="TxtSafe21" runat="server" style="text-align: right" Width="85px" MaxLength="8"></asp:TextBox></td>
            <td style="width: 91px; height: 25px">
                <asp:TextBox ID="TxtSafe22" runat="server" ReadOnly="True" style="text-align: right"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 113px; text-align: right">
                <strong id="c3">100</strong></td>
            <td style="width: 82px">
                <asp:TextBox ID="TxtSafe31" runat="server" style="text-align: right" Width="85px" MaxLength="8"></asp:TextBox></td>
            <td style="width: 91px">
                <asp:TextBox ID="TxtSafe32" runat="server" ReadOnly="True" style="text-align: right"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 113px; text-align: right">
                <strong id="c4">50</strong></td>
            <td style="width: 82px">
                <asp:TextBox ID="TxtSafe41" runat="server" style="text-align: right" Width="85px" MaxLength="8"></asp:TextBox></td>
            <td style="width: 91px">
                <asp:TextBox ID="TxtSafe42" runat="server" ReadOnly="True" style="text-align: right"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 113px; text-align: right; height: 9px;">
                <strong id="c5">20</strong></td>
            <td style="width: 82px; height: 9px;">
                <asp:TextBox ID="TxtSafe51" runat="server" Width="85px" style="text-align: right" MaxLength="8"></asp:TextBox></td>
            <td style="width: 91px; height: 9px;">
                <asp:TextBox ID="TxtSafe52" runat="server" ReadOnly="True" style="text-align: right"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 113px; text-align: right; height: 28px;">
                <strong id="c6">10</strong></td>
            <td style="width: 82px; height: 28px;">
                <asp:TextBox ID="TxtSafe61" runat="server" style="text-align: right" Width="85px" MaxLength="8"></asp:TextBox></td>
            <td style="width: 91px; height: 28px;">
                <asp:TextBox ID="TxtSafe62" runat="server" ReadOnly="True" style="text-align: right"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 23px; width: 113px; text-align: right;">
                <strong id="c7">5</strong></td>
            <td style="width: 82px; height: 23px">
                <asp:TextBox ID="TxtSafe71" runat="server" style="text-align: right" Width="85px" MaxLength="8"></asp:TextBox></td>
            <td style="width: 91px; height: 23px">
                <asp:TextBox ID="TxtSafe72" runat="server" ReadOnly="True" style="text-align: right"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 113px; text-align: right">
                <strong id="c8">2</strong></td>
            <td style="width: 82px">
                <asp:TextBox ID="TxtSafe81" runat="server" style="text-align: right" Width="85px" MaxLength="8"></asp:TextBox></td>
            <td style="width: 91px">
                <asp:TextBox ID="TxtSafe82" runat="server" ReadOnly="True" style="text-align: right"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 113px; text-align: right" id="c9">
                <strong>
                1</strong></td>
            <td style="width: 82px">
                <asp:TextBox ID="TxtSafe91" runat="server" style="text-align: right" Width="84px" MaxLength="8"></asp:TextBox></td>
            <td style="width: 91px">
                <asp:TextBox ID="TxtSafe92" runat="server" ReadOnly="True" style="text-align: right"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 113px; text-align: center; height: 28px;">
                </td>
            <td colspan="1" style="width: 82px; height: 28px; text-align: right">
                <strong>Coins</strong></td>
            <td style="height: 28px; width: 152px;" colspan="2">
                <asp:TextBox ID="TxtChangeRs" runat="server" style="text-align: right" MaxLength="10" Width="149px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 113px; text-align: center; height: 28px;">
                </td>
            <td colspan="1" style="width: 82px; text-align: right; height: 28px;">
                <strong>Late Cash</strong></td>
            <td colspan="2" style="height: 28px; width: 152px;">
                <asp:TextBox ID="TxtLateCash" runat="server" Width="149px" style="text-align: right" MaxLength="10"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 113px; text-align: center; height: 21px;">
                </td>
            <td colspan="1" style="width: 82px; text-align: right; height: 21px;">
                <strong>Total</strong></td>
            <td colspan="2" style="height: 21px; width: 152px;">
                <input id="TxtSafeTot" runat="server" readonly="readonly" style="width: 148px; text-align: right"
                    type="text" /></td>
        </tr>
        <tr>
            <td colspan="3" style="height: 21px; text-align: right">
                <strong>Cash Book Balance</strong></td>
            <td colspan="2" style="height: 21px; width: 152px;">
                <asp:TextBox ID="TxtCashbalance" runat="server" MaxLength="20" style="text-align: right"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="5" style="height: 9px; text-align: left">
                <strong><span style="font-size: 11pt">Whether Burglary Alarm Working or not </span>?</strong>
                <asp:RadioButton ID="rdb_Yes" runat="server" Font-Bold="True" Text="Yes" GroupName="b" />
                &nbsp;
                <asp:RadioButton ID="rdb_No" runat="server" Font-Bold="True" Text="No" Width="36px" GroupName="b" /><br />
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:Button ID="btnConfirm" runat="server" Text="CONFIRM" OnClientClick="return ConfirmClick()" Font-Bold="True" />
                <input id="btnExit" type="button" value="EXIT" onclick="return btnExit_onclick()" style="width: 81px; font-weight: bold;" /></td>
        </tr>
    </table>
    &nbsp; &nbsp;
</asp:Content>

