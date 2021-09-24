/*
 * Nested - Extra Components
 */

$(function () {

    var updateOutput = function (e) {
        var list = e.length ? e : $(e.target),
            output = list.data('output');
        if (window.JSON) {
            output.val(window.JSON.stringify(list.nestable('serialize'))); //, null, 2));
        } else {
            output.val('JSON browser support required for this demo.');
        }
    };

    // activate Nestable for list 1
    $('#nestable9').nestable({
        group: 1
    })
        .on('change', updateOutput).nestable('collapseAll');

    // activate Nestable for list 2
    $('#nestable3').nestable({
        group: 1
    })
        .on('change', updateOutput).nestable('collapseAll');
   
  // activate Nestable for list 4
  $('#nestable4').nestable({
      group: 1
  }).nestable('collapseAll').on('change', updateOutput);
  // activate Nestable for list 5
  $('#nestable5').nestable({
      group: 1
  }).nestable('collapseAll').on('change', updateOutput);
  // activate Nestable for list 6
  $('#nestable6').nestable({
      group: 1
  }).nestable('collapseAll').on('change', updateOutput);
  // activate Nestable for list 4
  $('#nestable7').nestable({
      group: 1
  }).nestable('collapseAll').on('change', updateOutput);
  // activate Nestable for list 5
  $('#nestable8').nestable({
      group: 1
  }).nestable('collapseAll').on('change', updateOutput);



  //$('#testlist1').nestable({
  //    group: 1
  //}).nestable('collapseAll').on('change', updateOutput);
  //  $('#testlist2').nestable({
  //    group: 1
  //  }).nestable('collapseAll').on('change', updateOutput);
  //  $('#testlist3').nestable({
  //    group: 1
  //  }).nestable('collapseAll').on('change', updateOutput);
  //  $('#testlist4').nestable({
  //    group: 1
  //  }).nestable('collapseAll').on('change', updateOutput);
  //  $('#testlist5').nestable({
  //    group: 1
  //  }).nestable('collapseAll').on('change', updateOutput);



    // output initial serialised data
    updateOutput($('#nestable9').data('output', $('#nestable-output')));
    updateOutput($('#nestable3').data('output', $('#nestable2-output')));
    updateOutput($('#nestable4').data('output', $('#nestable4-output')));
    updateOutput($('#nestable5').data('output', $('#nestable5-output')));
    updateOutput($('#nestable6').data('output', $('#nestable6-output')));
    updateOutput($('#nestable7').data('output', $('#nestable7-output')));
    updateOutput($('#nestable8').data('output', $('#nestable8-output')));

    //updateOutput($('#testlist1').data('output', $('#testlist1-output')));
    //updateOutput($('#testlist2').data('output', $('#testlist2-output')));
    //updateOutput($('#testlist3').data('output', $('#testlist3-output')));
    //updateOutput($('#testlist4').data('output', $('#testlist4-output')));
    //updateOutput($('#testlist5').data('output', $('#testlist5-output')));
    $('#nestable-menu').on('click', function (e) {
        var target = $(e.target),
            action = target.data('action');
        if (action === 'expand-all') {
            $('.dd').nestable('expandAll');
        }
        if (action === 'collapse-all') {
            $('.dd').nestable('collapseAll');
        }
    });

    //$('#nestable3').nestable();

});