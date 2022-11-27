function getValue(id) {
    return document.getElementById(id).value.trim();
}
function showError(key, mess) {
    document.getElementById(key + '_error').innerHTML = mess;
}

function soam(){
    var ip = getValue('quan');
    if (ip < 0)
        showError('quan','Vui lòng không nhập số âm(nếu nhập trả về 1)')
}