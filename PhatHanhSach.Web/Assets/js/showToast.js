function showSuccessToast(mess) {
    $.toast({
        heading: 'Thao tác thành công',
        text: mess,
        hideAfter: 4000,
        icon: 'success',
        stack: 3,
        allowToastClose: true,
        position: 'top-right',
        showHideTransition: 'fade'
    })
}

function showErrorToast(mess) {
    $.toast({
        heading: 'Lỗi',
        text: mess,
        hideAfter: 4000,
        icon: 'error',
        stack: 3,
        allowToastClose: true,
        position: 'top-right',
        showHideTransition: 'fade'
    })
}