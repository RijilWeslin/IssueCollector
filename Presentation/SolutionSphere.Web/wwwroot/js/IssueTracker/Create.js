//variables
var solutionArea = 0;
$(document).ready(function () {
    $("#solutionAvailableCheckbox").click(function () {
        console.log("clicked");
        if ($(this)[0].checked) {
            addSolutionArea($("#issueSolutionArea"));
            $("#issueSolutionArea").removeClass("d-none");
            $("#issueSolutionArea").addClass("d-block");
        }
        else {
            $("#issueSolutionArea").removeClass("d-block");
            $("#issueSolutionArea").addClass("d-none");
        }
    });
    $("#createIssueBtn").click(function () {
        if (!$("#solutionAvailableCheckbox")[0].checked) {
            $("#issueSolutionArea").html("");
        }
    });
});

function addSolutionArea(elem) {
    elem.append(
        "<div>Solution " + (solutionArea + 1) + "</div>" +
        "<textarea class='form-control' name='Solution["+solutionArea+"].Solution'></textarea>"
    );
    solutionArea = solutionArea + 1;
}