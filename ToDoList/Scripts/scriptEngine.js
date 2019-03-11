"use strict"
let $taskId;
let $taskName;
let $taskObjective;
let $taskPriority;
let $taskCategory;

$(function () {
    $('.Sp').on('click', function () {

        $taskId = $(this).attr('name');
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
        editTaskArray[0] = $taskId;
        editTaskArray[1] = $("#modalTitle").val();
        editTaskArray[2] = $("#objectiveTask").val();
        editTaskArray[3] = $('select[name="optionsPriority"]').find('option:selected').val();
        editTaskArray[4] = $('select[name="optionsCategory"]').find('option:selected').val();

        let editPostData = { _Fields: editTaskArray };

        $.ajax({
            url: '/Account/EditTask',
            type: 'POST',
            data: editPostData,
            dataType: "json",
            traditional: true,
            success: function (data) {
                $("div[name=" + $taskId + "]").find("h1").text(data.rName);
                $("div[name=" + $taskId + "]").find("textarea").val(data.rObjective);
                $("div[name=" + $taskId + "]").find("span").eq(0).text(data.rCategory);
                $("div[name=" + $taskId + "]").find("span").eq(1).text(data.rPriority);
                $("#myModal").modal('hide');
            }
        });
    });

    $('.Sp').on('mouseenter', function () {
        $taskId = $(this).attr('name');
    });

    $(".btn-warning").on('click', function () {
        let idPostData = { _TaskId: $taskId };

        $.ajax({
            url: '/Account/DeleteTask',
            type: 'POST',
            data: idPostData,
            dataType: "json",
            traditional: true,
            success: function (data) {
                $("div[name=" + data + "]").empty();
            }
        });
     });
});