"use strict"
let $taskName;
let $taskObjective;
let $taskPriority;
let $taskCategory;

$(function () {
    $('.Sp').on('click', function () {
        $taskName = $(this).find("h1").text();
        $taskObjective = $(this).find("textarea").text();
        $taskCategory = $(this).find("span").eq(0).text();
        $taskPriority = $(this).find("span").eq(1).text();
    });

    $("#myModal").on('show.bs.modal', function (event) {
        let modal = $(this);
        modal.find('#modalTitle').val($taskName.replace(/\s/g, ''));
        modal.find('#objectiveTask').val($taskObjective);

        $('option:selected', 'select[name="optionsCategory"]').removeAttr('selected');
        $('select[name="optionsCategory"]').find('option:contains("' + $taskCategory + '")').attr("selected", true);
        // $('select[name="options"]').find('option[value="3"]').attr("selected", true);
        // alert($('select[name="optionsCategory"]').find('option:selected').val());
        $('option:selected', 'select[name="optionsPriority"]').removeAttr('selected');
        $('select[name="optionsPriority"]').find('option:contains("' + $taskPriority + '")').attr("selected", true);
    });

    $("#close").on('click', function () {

    });

    $("#save").on('click', function () {
        let editTaskArray = new Array();
        editTaskArray[0] = $taskName;
        editTaskArray[1] = $taskObjective;
        editTaskArray[2] = $("#modalTitle").text();
        editTaskArray[3] = $("#objectiveTask").text();
        editTaskArray[4] = $('select[name="optionsPriority"]').find('option:selected').val();
        editTaskArray[5] = $('select[name="optionsCategory"]').find('option:selected').val();

        let editPostData = { _Fields: editTaskArray };

        $.ajax({
            url: '/Account/EditTask',
            type: 'POST',
            data: editPostData,
            dataType: "json",
            traditional: true,
            success: function () {
                $("#myModal").modal('hide');
            }
        });
    });
});