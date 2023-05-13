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
  // Numbered Wizard
  // --------------------------------------------------------------------
  const wizardNumbered = document.querySelector('.wizard-numbered'),
    wizardNumberedBtnNextList = [].slice.call(wizardNumbered.querySelectorAll('.btn-next')),
    wizardNumberedBtnPrevList = [].slice.call(wizardNumbered.querySelectorAll('.btn-prev')),
    wizardNumberedBtnSubmit = wizardNumbered.querySelector('.btn-submit');

  if (typeof wizardNumbered !== undefined && wizardNumbered !== null) {
      const numberedStepper = new Stepper(wizardNumbered, {

          
      linear: false
    });
    if (wizardNumberedBtnNextList) {
      wizardNumberedBtnNextList.forEach(wizardNumberedBtnNext => {
        wizardNumberedBtnNext.addEventListener('click', event => {
            numberedStepper.next();
           
        });
      });
    }
    if (wizardNumberedBtnPrevList) {
      wizardNumberedBtnPrevList.forEach(wizardNumberedBtnPrev => {
        wizardNumberedBtnPrev.addEventListener('click', event => {
            numberedStepper.previous();

        });
      });
    }
    if (wizardNumberedBtnSubmit) {
        wizardNumberedBtnSubmit.addEventListener('click', event => {
          /*  document.getElementById("regForm").submit();*/
            
      /*  alert('abduk.!!');*/
      });
    }
  }


  
  // Modern Vertical Wizard
  // --------------------------------------------------------------------
  const wizardModernVertical = document.querySelector('.wizard-modern-vertical'),
    wizardModernVerticalBtnNextList = [].slice.call(wizardModernVertical.querySelectorAll('.btn-next')),
    wizardModernVerticalBtnPrevList = [].slice.call(wizardModernVertical.querySelectorAll('.btn-prev')),
    wizardModernVerticalBtnSubmit = wizardModernVertical.querySelector('.btn-submit');
  if (typeof wizardModernVertical !== undefined && wizardModernVertical !== null) {
    const modernVerticalStepper = new Stepper(wizardModernVertical, {
      linear: false
    });
    if (wizardModernVerticalBtnNextList) {
      wizardModernVerticalBtnNextList.forEach(wizardModernVerticalBtnNext => {
        wizardModernVerticalBtnNext.addEventListener('click', event => {
          modernVerticalStepper.next();
        });
      });
    }
    if (wizardModernVerticalBtnPrevList) {
      wizardModernVerticalBtnPrevList.forEach(wizardModernVerticalBtnPrev => {
        wizardModernVerticalBtnPrev.addEventListener('click', event => {
          modernVerticalStepper.previous();
        });
      });
    }
    if (wizardModernVerticalBtnSubmit) {
      wizardModernVerticalBtnSubmit.addEventListener('click', event => {
        alert('Submittedjshgjsg..!!');
      });
    }
  }
})();
