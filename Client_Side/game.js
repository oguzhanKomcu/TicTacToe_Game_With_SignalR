$(document).ready(()=>{
           
    const connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7060/gamehub").build();
    connection.start();
  
    $(".disabled").attr("disabled","disabled");
    $("body").on("click",".users",function(){
        $(".users").each((index,item)=>{
            item.classList.remove("active");
        });
        $(this).addClass("active");
    })
   
    $(".users").click(function(){
    $(".users").each((index,item)=>{
        item.classList.remove("active");
    });
    $(this).addClass("active");});
    $("#btnSignIn").click(()=>{
       const nickName = $("#txtNickName").val();
       connection.invoke("GetNickName",nickName).catch(error=> console.log(error));
       $(".disabled").removeAttr("disabled");
       $(".gameContainer").css({ visibility: "visible"})
    
    });
    $("a").click(()=>{
        const user = $("a").html();

       console.log(user);
     
     });
    connection.on("clients", clients=>{
        console.log(clients);
          $("#_clients").html("");
        $.each(clients,(index,item)=>{
        // const user= $(".users").first().clone();
        //  user.removeClass("active");
        //  user.html(item.nickName)
        $("#_clients").prepend(`<li><a>${item.nickName}</a></li>`);
    })
        
      })

      $(document).on('click', 'li', function(){
        $(this).addClass('active').siblings().removeClass('active')
        })
     $("#sendRequest").click(()=>{
          const clientName = $("#_clients").children(".active").first().text();
           console.log(clientName)
        const message = "O"
          connection.invoke("SendMessageAsync",message,clientName)

          const _message =$(".message").clone();
          _message.removeClass("message");
          _message.find(".gidenMesaj").html(message);
       //   _message.find(".userName")[0].innerHTML="You";
          $(".messages").append(_message)
          
      }) 

      connection.on("receiveMessage", (message,nickName) => {
        $(function(){
          window.alert(`${nickName} adlı kullanıcı sizi oyuna davet ediyor`); 
          });
        // const _message =$(".message").clone();
        // _message.removeClass("message");
        // $(".gelenmesaj2").append(`<p><b>"${message}"</b></p>`);
        // _message.find(".gidenMesaj")[0].innerHTML=nickName;
        // $(".message").append(_message)
        
    })
     
})
