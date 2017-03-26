$(function () {
    $("#srcomSelect").click(function () {
        console.log('aaaaa');
        $("#srcomSelect").toggleClass('active-select');
        $("#cvsSelect").toggleClass('active-select');
        $("#cvs-menu").toggle();
        $("#srcom-menu").toggle();
    });

    $("#cvsSelect").click(function () {
        console.log('bbbb');
        $("#srcomSelect").toggleClass('active-select');
        $("#cvsSelect").toggleClass('active-select');
        $("#cvs-menu").toggle();
        $("#srcom-menu").toggle();
    });
});