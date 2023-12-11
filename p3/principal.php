<?php
	include 'conexion.php';
	
	$pdo = new Conexion();
	
	//Listar registros y consultar registro
	if($_SERVER['REQUEST_METHOD'] == 'GET')
	{
		if (isset($_GET["id"]))
		{
			$sqlp="select id_persona, nombres, paterno, materno, sexo, fec_nac from personas where id_persona=:id";
			$sql = $pdo->prepare($sqlp);
			$sql->bindValue(':id', $_GET["id"]);
			$sql->execute();
			$sql->setFetchMode(PDO::FETCH_ASSOC);
			echo json_encode($sql->fetchAll());
			header("HTTP/1.1 200 hay datos");		
			exit;		
		}
		else
		{
			$sqlp="select id_persona, nombres, paterno, materno, sexo, fec_nac from personas where id_persona in (select id_persona from estudiante)";
			$sql = $pdo->prepare($sqlp);
			$sql->execute();
			$sql->setFetchMode(PDO::FETCH_ASSOC);
			echo json_encode($sql->fetchAll());
			header("HTTP/1.1 200 hay datos");
			exit;		
		}
			
	}
	
	//Insertar registro
	if($_SERVER['REQUEST_METHOD'] == 'POST')
	{
		$sqlp="INSERT INTO personas (id_persona,nombres,paterno,materno,fec_nac,sexo) VALUES (:id,:nombres,:paterno,:materno,:fec_nac,:sexo)";
		$sqlp2="INSERT INTO estudiante (id_persona) VALUES (:id)";

		$sql = $pdo->prepare($sqlp);
		$sql->bindValue(':id', $_GET["id"]);
		$sql->bindValue(':nombres', $_GET["nombres"]);
		$sql->bindValue(':paterno', $_GET["paterno"]);
		$sql->bindValue(':materno', $_GET["materno"]);
		$sql->bindValue(':fec_nac', $_GET["fec_nac"]);
		$sql->bindValue(':sexo', $_GET["sexo"]);
		$sql->execute();
		$sql2=$pdo->prepare($sqlp2);
		$sql2->bindValue(':id', $_GET["id"]);
		$sql2->execute();
		echo json_encode('Registro Agregado');
		header("HTTP/1.1 200 ejecucion correcta");
		exit;
	}
	
	if($_SERVER['REQUEST_METHOD'] == 'PUT')
	{		

		$sqlp="UPDATE personas SET nombres = :nombres, paterno = :paterno, materno = :materno, fec_nac = :fec_nac, sexo = :sexo WHERE id_persona = :id";
		$sql = $pdo->prepare($sqlp);
		$sql->bindValue(':id', $_GET["id"]);
		$sql->bindValue(':nombres', $_GET["nombres"]);
		$sql->bindValue(':paterno', $_GET["paterno"]);
		$sql->bindValue(':materno', $_GET["materno"]);
		$sql->bindValue(':fec_nac', $_GET["fec_nac"]);
		$sql->bindValue(':sexo', $_GET["sexo"]);
		$sql->execute();
		echo json_encode('Registro Actualizado');
		header("HTTP/1.1 200 ejecucion correcta");
		exit;
	}
	
	if($_SERVER['REQUEST_METHOD'] == 'DELETE')
	{
		$sqlp="DELETE FROM estudiante WHERE id_persona = :id";
		$sqlp2="DELETE FROM personas WHERE id_persona = :id";
		$sql = $pdo->prepare($sqlp);
		$sql->bindValue(':id', $_GET["id"]);
		$sql->execute();
		$sql2 = $pdo->prepare($sqlp2);
		$sql2->bindValue(':id', $_GET["id"]);
		$sql2->execute();
		echo json_encode('Registro Eliminado');
		header("HTTP/1.1 200 ejecucion correcta");
		exit;
	}
	
	header("HTTP/1.1 400 Bad Request");
?>