<?php 
    
    if ($_SERVER['REQUEST_METHOD'] == 'POST') { 
          
        function get_data() { 
            $datae = array(); 
            $datae[] = array( 
                'Vorname' => $_POST['vorname'], 
                'Nachname' => $_POST['name'], 
                'Instagram' => $_POST['instagram'], 
            ); 
            return json_encode($datae); 
        } 
          
        $name = "form_input"; 
        $file_name = $name . '.json'; 
       
        if(file_put_contents( 
            "$file_name", get_data())) { 
            header ('location: success.html');
            } 
        else { 
            echo 'There is some error'; 
        } 
    } 
?>