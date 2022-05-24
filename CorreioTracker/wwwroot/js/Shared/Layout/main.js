function __SentEmail(emailSentModel)
{
    $.ajax({
        async: true,
        type: "POST",
        url: "Global/SentMessage",
        data: { model: emailSentModel },
        success: function (data)
        {
            siteController.modalInfoPopUp.mountModalMessage("Email enviado com sucesso !", "", true)
        },
        error: function (data)
        {
            siteController.modalInfoPopUp.mountModalMessage("Erro interno inesperado!", "", false)
        }
    })
}

class MainController
{
    constructor()
    {
        $("#partnership__submit__button").click(function (e)
        {
            e.preventDefault()            

            let emailOwner = $("#partnership__email__input").val()
            let messageHeader = $("#partnership__header__input").val()
            let messageBodyText = $("#partnership__textarea").val()

            let model = {}
            model.Address = emailOwner;
            model.Subject = messageHeader
            model.Body = messageBodyText;

            let fill = "" //Alert message if the client not fill the fields...

            if (messageHeader === "")
                fill += `Cabeçalho do email! <br/> <hr/>`

            if (messageBodyText === "")
                fill += `Corpo do email! <br/> <hr/>`

            if (emailOwner === "")
                fill += `Seu email! <br/> <hr/>`

            if (fill !== "")
                siteController.modalInfoPopUp.mountModalMessageHTML("Preencha os seguintes campos:", fill, false)

            //success fill of the message 
            if (fill === "")
            {
                __SentEmail(model)
            }                
        })
    }
}
