<?

	header("Cache-Control: no-cache"); 

	header("Pragma: no-cache");



	include("../cms/admin/client_info.php");

	require_once(LOGICA."/Logic_Client.php");

?>

<!DOCTYPE html>

<html>

    <head>

        <title>SEHS - Intranet Institucional</title>

        <meta http-equiv="content-type" content="text/html; charset=iso-8859-1" />

        <meta name="keywords" content="SEHS, Servicio Educacional Hogar y Salud, Intranet Institucional" />

        <meta name="DESCRIPTION" content="" />

        <meta name="email" content="" />

        <meta name='robots' content='index, follow' />

        <meta name='googlebot' content='index, follow' />

        <meta name='generator' content='' />

        <meta name='origen' content='' />

        <meta name='author' content='' />

        <meta name='Locality' content='' />

        <meta name='lang' content='es' />

        <link rel="shortcut icon" type="image/x-icon" href="../favicon.ico" />

        <link rel="icon" type="image/x-icon" href="../favicon.ico" />



        <!-- <link href="login.css" rel="stylesheet" type="text/css" /> -->

<link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css"/>

<link href="css/font-awesome.min.css" rel="stylesheet" type="text/css"/>

<link href="css/simple-line-icons.min.css" rel="stylesheet" type="text/css"/>

<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css"/>

<link href="css/uniform.default.css" rel="stylesheet" type="text/css"/>

<link href="css/login.css" rel="stylesheet" type="text/css"/>

<link href="css/components.css" id="style_components" rel="stylesheet" type="text/css"/>

<link href="css/layout.css" rel="stylesheet" type="text/css"/>

<link href="custom.css" rel="stylesheet" type="text/css"/>



<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"> 

<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css">



<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>

<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>





<!-- END THEME STYLES -->

        

        <script language="javascript" type="text/javascript">	

			function Login(){

				if($.trim($('#txtUsuario').val())==''){alert("Falta ingresar el usuario"); $('#txtUsuario').focus(); return false;}

				if($.trim($('#txtClave').val())==''){alert("Falta ingresar la clave"); $('#txtClave').focus(); return false;}

				document.frmLogin.submit();

			}		

		</script> 

	

		

		<script type="text/javascript" src="<?=JAVASCRIPT?>/jquery-1.8.2.js"> </script>



		<script type="text/javascript" src="<?=JAVASCRIPT?>/fancybox/source/jquery.fancybox.js?v=2.1.4"></script>

        <link rel="stylesheet" type="text/css" href="<?=JAVASCRIPT?>/fancybox/source/jquery.fancybox.css" media="screen" />

		

</head>



<body class="login"> 

 <!-- BEGIN Publicidad -->

<div style="text-align: left;"> 
		<a href="../clubdellibrosehs/index.html" target="_blank" style= "left: 20px; position: fixed; top: 50px;">
	<img src="images/cdl.png" alt="" /></a>
</div> 
<div style="text-align: right;"> 
		<a href="#" target="_blank" style= "right: 20px; position: fixed; top: 50px;">
	<img src="images/devocion.png" alt="" /></a>
</div> 
<!-- END Publicidad -->

<!-- BEGIN LOGO -->

<div class="logo">

	<a href="../index.html">

	<img src="images/logo-big.png" alt=""/>
	
	</a>

</div>

<!-- END LOGO -->

<!-- BEGIN LOGIN -->

<div class="content">

	<!-- BEGIN LOGIN FORM -->

	<form id="frmLogin" name="frmLogin" class="login-form" method="post" action="http://www.solucionesasumedida.com/proyectos/sehs/validar_usuario.php">

		<h3 class="form-title">Ingrese Usuario y clave</h3>

		<div class="alert alert-danger display-hide">

			<button class="close" data-close="alert"></button>

			<span>

			Ingrese su usuario y Clave. </span>

		</div>

		<div class="form-group">

			<!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->

			<label class="control-label visible-ie8 visible-ie9">Usuario</label>

			<input class="form-control form-control-solid placeholder-no-fix" name="txtUsuario" id="txtUsuario" type="text" autocomplete="off" placeholder="Username" name="username"/>

		</div>

		<div class="form-group">

			<label class="control-label visible-ie8 visible-ie9">Clave</label>

			<input class="form-control form-control-solid placeholder-no-fix" name="txtClave" id="txtClave" type="password" autocomplete="off" placeholder="Password" name="password"/>

		</div>

		<div class="form-actions">

			<a href="javascript:void(0);" onclick="Login();" class="btn btn-success uppercase">Ingresar</a>

			<label class="rememberme check">

			<input type="checkbox" name="remember" value="1"/>Recordar </label>

			<a href="javascript:void(0);" id="forget-password" class="forget-password">Olvide mi clave</a>

            

		</div>

		<div class="create-account">

			<p><a href="http://sehs.org.pe/files/manual_coordinadores.pdf" target="_blank"><span>Manual</span> Coordinador Publicaciones</a></p>

			<p><a href="http://sehs.org.pe/files/GUIA_PEDIDO_IGLESIA2016.pdf" target="_blank"><span>Manual</span> Guía de Pedido 2016</a></p>

			<p><a href="http://sehs.org.pe/files/PROCESO_PEDIDO_IGLESIA2016.pdf" target="_blank"><span>Manual</span> Proceso de Pedido 2016</a></p>

		</div>

	</form>

	<!-- END LOGIN FORM -->



</div>

<div class="copyright">

	 2015 © TI - SEHS. Servicio Educacional Hogar y Salud.

</div>

<!-- END LOGIN -->



    </body>

</html>







<script language="javascript" type="text/javascript">	

	$(document).ready(function(){

		$("#txtUsuario").keydown(function(e){			

			var vKeyCode = (e.keyCode ? e.keyCode : e.which);

			if(vKeyCode==13) Login();

		});

		$("#txtClave").keydown(function(e){

			var vKeyCode = (e.keyCode ? e.keyCode : e.which);

			if(vKeyCode==13) Login();

		});

		$("#forget-password").click(function(e){ $.fancybox({ width:550, height:450, prevEffect:'none', nextEffect:'none', closeBtn: true, helpers:{ title:{type:'inside'}}, type:'iframe', href:'http://www.solucionesasumedida.com/proyectos/sehs/Recuperar_Clave.php'}); }); 		

	});

</script>