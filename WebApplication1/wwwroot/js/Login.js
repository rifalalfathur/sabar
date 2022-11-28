function LogIn() {
    let result = new Object();
    result.Email = $("#email").val();
    result.Password = $("#password").val();
    console.log(result.Email);
    console.log(result.Password);
    //let DivId = $('departId')

    
    $.ajax({
        url: `https://localhost:7138/api/Account/Login`,
        type: 'POST',
        data: JSON.stringify(result),
        dataType: 'json',
        headers: {
            'content-Type': 'application/json'
        },
        success: function (lod) {
            console.log(lod);
            sessionStorage.setItem("token", lod.token);
            console.log(lod.token);
            window.location.replace("../department")

        }
    })
}
