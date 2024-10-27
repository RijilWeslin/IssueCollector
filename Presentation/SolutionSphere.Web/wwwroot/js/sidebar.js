$(document).ready(function () {
    $(".sideMenuOption").click(function () {
        if ($(this).find(".subMenu").hasClass("d-none")) {
            $(this).find(".subMenu").removeClass("d-none");
            $(this).find(".subMenu").addClass("d-block");            
            $(this).find(".menuExpandCollapse").removeClass("fa-sort-down");
            $(this).find(".menuExpandCollapse").addClass("fa-sort-up");
        }
        else {
            $(this).find(".subMenu").addClass("d-none");
            $(this).find(".subMenu").removeClass("d-block");
            $(this).find(".menuExpandCollapse").addClass("fa-sort-down");
            $(this).find(".menuExpandCollapse").removeClass("fa-sort-up");
        }        
    });
});