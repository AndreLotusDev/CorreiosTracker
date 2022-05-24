class SiteController
{
   modalInfoPopUp = new ModalInfoPopUp()
}

class ModalInfoPopUp
{
    mountModalMessage = function (message, body, success = true)
    {
        Swal.fire(
            message,
            body,
            success ? 'success' : 'error'
        )
    }

    mountModalMessageHTML = function (message, html, success = true)
    {
        Swal.fire(
            message,
            html,
            success ? 'success' : 'error'
        )
    }
}
