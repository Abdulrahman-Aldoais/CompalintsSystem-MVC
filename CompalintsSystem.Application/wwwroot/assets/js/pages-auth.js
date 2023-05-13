/**
 *  Pages Authentication
 */

'use strict';
const formAuthentication = document.querySelector('#formAuthentication');

document.addEventListener('DOMContentLoaded', function (e) {
  (function () {
    // Form validation for Add new record
    if (formAuthentication) {
      const fv = FormValidation.formValidation(formAuthentication, {
        fields: {
          name: {
            validators: {
              notEmpty: {
                message: 'يرجى ادخال الاسم '
              },
              stringLength: {
                min: 6,
                message: 'يجب ان يتكون اسم المستخدم اكثر من 6 احرف '
              }
            }
          },
          username: {
            validators: {
              notEmpty: {
                message: 'يرجى ادخال اسم المستخدم'
              },
              stringLength: {
                min: 6,
                message: 'يجب ان يتكون اسم المستخدم اكثر من 6 احرف '
              }
            }
          },
          email: {
            validators: {
              notEmpty: {
                message: 'يرجى ادخال البريد الالكتروني'
              },
              emailAddress: {
                message: 'يرجى ادخال عنوان بريد الكتروني صالح'
              }
            }
          },
          'email-username': {
            validators: {
              notEmpty: {
                message: 'يرجى ادخال اسم المستخدم او البريد الالكتروني'
              },
              stringLength: {
                min: 6,
                message: 'يجب ان يتكون اسم المستخدم اكثر من 6 احرف  '
              }
            }
          },
          password: {
            validators: {
              notEmpty: {
                message: 'من فضلك ادخل كلمة المرور'
              },
              stringLength: {
                min: 6,
                message: 'يجب ان تتكون كلمة المرور اكثر من 6 احرف او ارقام'
              }
            }
          },
          'confirm-password': {
            validators: {
              notEmpty: {
                message: 'يرجى التأكد من كلمة المرور'
              },
              identical: {
                compare: function () {
                  return formAuthentication.querySelector('[name="password"]').value;
                },
                message: 'كلمة المرور وتأكيدها ليست هي نفسها'
              },
              stringLength: {
                min: 6,
                message: 'يجب ان تتكون كلمة المرور اكثر من 6 احرف او ارقام'
              }
            }
          },
          terms: {
            validators: {
              notEmpty: {
                message: 'يرجى توافق الشروط والاحكام'
              }
            }
          }
        },
        plugins: {
          trigger: new FormValidation.plugins.Trigger(),
          bootstrap5: new FormValidation.plugins.Bootstrap5({
            eleValidClass: '',
            rowSelector: '.mb-3'
          }),
          submitButton: new FormValidation.plugins.SubmitButton(),

          defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
          autoFocus: new FormValidation.plugins.AutoFocus()
        },
        init: instance => {
          instance.on('plugins.message.placed', function (e) {
            if (e.element.parentElement.classList.contains('input-group')) {
              e.element.parentElement.insertAdjacentElement('afterend', e.messageElement);
            }
          });
        }
      });
    }

    //  Two Steps Verification
    const numeralMask = document.querySelectorAll('.numeral-mask');

    // Verification masking
    if (numeralMask.length) {
      numeralMask.forEach(e => {
        new Cleave(e, {
          numeral: true
        });
      });
    }
  })();
});
