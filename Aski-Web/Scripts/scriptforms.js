

$(document).ready(function (){

    

});

function OnSuccessCourseRegister(data){

    M.toast({html: data.msg})
    
}

function OnFailureCourseRegister(data){

    M.toast({html: data})
    
}