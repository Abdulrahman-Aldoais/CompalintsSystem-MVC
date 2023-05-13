/**
 *  Form Wizard
 */

'use strict';

$(function () {
  const select2 = $('.select2'),
    selectPicker = $('.selectpicker');

  // Bootstrap select
  if (selectPicker.length) {
    selectPicker.selectpicker();
  }

  // select2
  if (select2.length) {
    select2.each(function () {
      var $this = $(this);
      $this.wrap('<div class="position-relative"></div>');
      $this.select2({
        placeholder: 'Select value',
        dropdownParent: $this.parent()
      });
    });
  }
});

(function () {
  // Icons Wizard
  // --------------------------------------------------------------------
  const wizardIcons = document.querySelector('.wizard-icons-example');

  if (typeof wizardIcons !== undefined && wizardIcons !== null) {
    const wizardIconsBtnNextList = [].slice.call(wizardIcons.querySelectorAll('.btn-next')),
      wizardIconsBtnPrevList = [].slice.call(wizardIcons.querySelectorAll('.btn-prev')),
      wizardIconsBtnSubmit = wizardIcons.querySelector('.btn-submit');
      

    const iconsStepper = new Stepper(wizardIcons, {
      linear: false
    });
    if (wizardIconsBtnNextList) {
      wizardIconsBtnNextList.forEach(wizardIconsBtnNext => {
        wizardIconsBtnNext.addEventListener('click', event => {
          iconsStepper.next();
        });
      });
    }
    if (wizardIconsBtnPrevList) {
      wizardIconsBtnPrevList.forEach(wizardIconsBtnPrev => {
        wizardIconsBtnPrev.addEventListener('click', event => {
          iconsStepper.previous();
        });
      });
    }
    if (wizardIconsBtnSubmit) {
      wizardIconsBtnSubmit.addEventListener('click', event => {
        alert('تم الارسال..!!');
      });
    }
  }

  // Vertical Icons Wizard
  // --------------------------------------------------------------------
  const wizardIconsVertical = document.querySelector('.wizard-vertical-icons-example');

  if (typeof wizardIconsVertical !== undefined && wizardIconsVertical !== null) {
    const wizardIconsVerticalBtnNextList = [].slice.call(wizardIconsVertical.querySelectorAll('.btn-next')),
      wizardIconsVerticalBtnPrevList = [].slice.call(wizardIconsVertical.querySelectorAll('.btn-prev')),
      wizardIconsVerticalBtnSubmit = wizardIconsVertical.querySelector('.btn-submit');

    const verticalIconsStepper = new Stepper(wizardIconsVertical, {
      linear: false
    });

    if (wizardIconsVerticalBtnNextList) {
      wizardIconsVerticalBtnNextList.forEach(wizardIconsVerticalBtnNext => {
        wizardIconsVerticalBtnNext.addEventListener('click', event => {
          verticalIconsStepper.next();
        });
      });
    }
    if (wizardIconsVerticalBtnPrevList) {
      wizardIconsVerticalBtnPrevList.forEach(wizardIconsVerticalBtnPrev => {
        wizardIconsVerticalBtnPrev.addEventListener('click', event => {
          verticalIconsStepper.previous();
        });
      });
    }
    if (wizardIconsVerticalBtnSubmit) {
      wizardIconsVerticalBtnSubmit.addEventListener('click', event => {
        alert('Submitted..!!');
      });
    }
  }

  // Icons Modern Wizard
  // --------------------------------------------------------------------
  const wizardIconsModern = document.querySelector('.wizard-modern-icons-example');

  if (typeof wizardIconsModern !== undefined && wizardIconsModern !== null) {
    const wizardIconsModernBtnNextList = [].slice.call(wizardIconsModern.querySelectorAll('.btn-next')),
      wizardIconsModernBtnPrevList = [].slice.call(wizardIconsModern.querySelectorAll('.btn-prev')),
      wizardIconsModernBtnSubmit = wizardIconsModern.querySelector('.btn-submit');

    const modernIconsStepper = new Stepper(wizardIconsModern, {
      linear: false
    });

    if (wizardIconsModernBtnNextList) {
      wizardIconsModernBtnNextList.forEach(wizardIconsModernBtnNext => {
        wizardIconsModernBtnNext.addEventListener('click', event => {
          modernIconsStepper.next();
        });
      });
    }
    if (wizardIconsModernBtnPrevList) {
      wizardIconsModernBtnPrevList.forEach(wizardIconsModernBtnPrev => {
        wizardIconsModernBtnPrev.addEventListener('click', event => {
          modernIconsStepper.previous();
        });
      });
    }
    if (wizardIconsModernBtnSubmit) {
      wizardIconsModernBtnSubmit.addEventListener('click', event => {
        alert('Submitted..!!');
      });
    }
  }

  // Icons Modern Wizard
  // --------------------------------------------------------------------
  const wizardIconsModernVertical = document.querySelector('.wizard-modern-vertical-icons-example');

  if (typeof wizardIconsModernVertical !== undefined && wizardIconsModernVertical !== null) {
    const wizardIconsModernVerticalBtnNextList = [].slice.call(wizardIconsModernVertical.querySelectorAll('.btn-next')),
      wizardIconsModernVerticalBtnPrevList = [].slice.call(wizardIconsModernVertical.querySelectorAll('.btn-prev')),
      wizardIconsModernVerticalBtnSubmit = wizardIconsModernVertical.querySelector('.btn-submit');

    const verticalModernIconsStepper = new Stepper(wizardIconsModernVertical, {
      linear: false
    });

    if (wizardIconsModernVerticalBtnNextList) {
      wizardIconsModernVerticalBtnNextList.forEach(wizardIconsModernVerticalBtnNext => {
        wizardIconsModernVerticalBtnNext.addEventListener('click', event => {
          verticalModernIconsStepper.next();
        });
      });
    }
    if (wizardIconsModernVerticalBtnPrevList) {
      wizardIconsModernVerticalBtnPrevList.forEach(wizardIconsModernVerticalBtnPrev => {
        wizardIconsModernVerticalBtnPrev.addEventListener('click', event => {
          verticalModernIconsStepper.previous();
        });
      });
    }
    if (wizardIconsModernVerticalBtnSubmit) {
      wizardIconsModernVerticalBtnSubmit.addEventListener('click', event => {
        alert('Submitted..!!');
      });
    }
  }
})();





 
 //////////////////////////////////////////////////////////////////////////////////
 ///////////////////////////////////////////////////////////////////
 var isvalid=true;
$( document ).ready(function() {
    $("#test").prop("disabled",true);
    $(".tabbody input[type=number]").blur(function(){
        validateSubmit();
    });
});
function validateSubmit()
{
    var retval = sumRowVals();
    $("#test").prop("disabled",!retval);
    $("#msgdiv").html(retval ? "":"Invalid inputs!!!");
}
function sumRowVals()
{
    isvalid=true;
    resetFigs();
    var rindx=1;
    $(".tabbody tr").each(function(){
        var temp=0;
        var cindx=1;
        $("input[type=number]",this).each(function(){
            var elval = !isNaN($(this).val()) ? parseInt($(this).val()):0;
            var sumcol = $("#ccol"+cindx);
            $(sumcol).html(parseInt($(sumcol).html())+elval);
            temp=temp+elval;
            cindx++;
            if(elval > 100){isvalid=false;}
            if(parseInt($(sumcol).html()) > 100){isvalid=false;}
        });
        if(rindx != $('.tabbody tr').length)
        {
            if(temp != 100){isvalid=false;}
            $("#rcol"+rindx).html(temp);
        }
        rindx++;
    });
    return isvalid;
}
function resetFigs()
{
    $('*[id*=ccol]').each(function() {
    $(this).html("0");
});
}
function SubmitForm()
{
    // your form submit code
}