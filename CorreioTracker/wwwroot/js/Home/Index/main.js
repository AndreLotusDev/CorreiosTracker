//copy the td of patthern hidden in index.cshtml
function __copyTd(fatherObject, position)
{
    let colData = $(fatherObject).find("td").eq(position).html()
    return colData
}

//copy the tr of json comming from correios
function __copyTr()
{
    $("#moves__info").attr("hidden", "")

    let trComplete = $(".moves__info--card")
    $(trComplete).removeAttr("hidden")

    let trModified = $(trComplete).parent().clone()

    $(trComplete).attr("hidden", "")

    return trModified
}

//every foreach on the JSON builds a new usefull line
function __foreachIntoJson(colData, colInfo, trModified)
{
    let txtTrInformation = $(trModified).html()
    txtTrInformation = txtTrInformation.replace("#HOUR", colData)
    txtTrInformation = txtTrInformation.replace("#INFORMATION", colInfo)
    $("#moves__body").append(txtTrInformation)
}

function __goesWrongIntegration()
{
    Swal.fire({
        icon: 'error',
        title: 'Opa, algo deu errado...',
        text: 'Parece que o servidor do correios está indisponivel!',
        footer: '<a href>Por que isso acontece?</a>'
    })
}

class Controller
{
    constructor()
    {
        //Sarch button
        $("#tracker__form--btn").click(function (e)
        {
            e.preventDefault()

            let trModified = __copyTr()

            let model = {}
            model.Codigo = $("#tracker__form--input").val()

            $.ajax({
                async: true,
                type: "POST",
                url: "Home/TrackingConsult",
                data: { model: model },
                success: function (data)
                {
                    $("#moves__info").removeAttr("hidden")

                    $(data).find("tr").each(function ()
                    {
                        let colData = __copyTd(this , 0)
                        let colInfo = __copyTd(this , 1)

                        __foreachIntoJson(colData, colInfo, trModified)
                    })
                },
                error: function (data)
                {
                    __goesWrongIntegration()
                }
            })
        })
    }
}

