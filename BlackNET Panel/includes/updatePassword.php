<?php 
require '../classes/Database.php';
require '../session.php';

if ($_SERVER['REQUEST_METHOD'] == "POST") {
	if ($csrf != $_POST['csrf']){
	   $user->redirect("../changePassword.php?msg=csrf");
	} else {
	  $id = $_POST['id'];
	  $oldusername = $_POST['oldUsername'];
	  $username = $_POST['Username'];
	  $email = $_POST['Email'];
	  $auth = $_POST['auth-state'];
	  $question = $_POST['questions'];
	  $answer = $_POST['answer'];
	  $sqenable = $_POST['sqenable'];
	  
	  if (!$_POST['Password'] || $_POST['Password'] == "") {
	  	$password = "No change";
	  } else {
	  	$password = $_POST['Password'];
	  }
	  $msg = $user->updateUser($id,$oldusername,$username,$email,$password,$auth,$question,$answer,$sqenable);
	  $user->redirect("../changePassword.php?msg=yes");
	}

}
?>