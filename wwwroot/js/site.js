var ContactsHandler = function () {

    var init = function () {
        //Add validation
        $.validator.unobtrusive.parse("#new-contact-form");
        $.validator.unobtrusive.parse("#edit-contact-form");
    };

    //launch Edit Contact popup
    $('.edit-button').click(function () {
        $('#editContactPopup').modal();
        //fill-up popup fields with selected contact row
        //the elements of both table row and popup match order
        var contactFields = this.parentElement.parentElement.children;
        var editFields = $('#edit-contact-form').find(".form-control").toArray();
        $.each(contactFields, function (index, value) {
            editFields[index].value = value.firstChild.data;            
        });
    });

    //launch New Contact popup
    $('#new-contact-button').click(function () {
        $('#newContactPopup').modal();
    });
    
    $('#submit-new-contact').click(function () {

        if ($('#new-contact-form').valid()) {
            $('#new-contact-form').submit();   
            $('#newContactPopup').modal("hide");
        }       
            
    });

    $('#submit-edit-contact').click(function () {

        if ($('#edit-contact-form').valid()) {
             $('#edit-contact-form').submit();
            $('#editContactPopup').modal("hide");
        }
  
    });
};



$(document).ready(function () {
    contactsHandler = new ContactsHandler();
});
