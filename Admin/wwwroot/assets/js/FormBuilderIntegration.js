$(document).ready(function () {
  
    var options = {

        // additional form action buttons- save, data, clear
        actionButtons: [],

        // enables/disables stage sorting
        allowStageSort: true,

        // append/prepend non-editable content to the form.
        append: false,
        prepend: false,

        // Control Position
        controlPosition: 'right',

        // control order
        controlOrder: [
            'autocomplete',
            'button',
            'checkbox-group',
            'checkbox',
            'date',
            'file',
            'header',
            'hidden',
            'number',
            'paragraph',
            'radio-group',
            'select',
            'text',
            'textarea',
        ],

        // or 'xml'
        dataType: 'json',

        // default fields
        defaultFields: [],

        // save, data, clear
        disabledActionButtons: [],

        // disabled attributes
        disabledAttrs: [],

        // disabled buttons
        disabledFieldButtons: {},

        // disabled subtypes
        disabledSubtypes: {},

        // disabled fields
        disableFields: [],

        // disables html in field labels
        disableHTMLLabels: false,

        // removes the injected style
        disableInjectedStyle: false,

        // opens the edit panel on added field
        editOnAdd: false,

        // adds custom control configs
        fields: [],

        // warns user if before the remove a field from the stage
        fieldRemoveWarn: false,

        // DOM node or selector
        fieldEditContainer: null,

        // add groups of fields at a time
        inputSets: [],

        // custom notifications
        notify: {
            error: console.error,
            success: console.log,
            warning: console.warn,
        },

        // callbakcs
        onAddField: (fieldData, fieldId) => fieldData,
        onAddOption: () => null,
        onClearAll: () => null,
        onCloseFieldEdit: () => null,
        onOpenFieldEdit: () => null,
        onSave: (evt, formData) => null,

        // replaces an existing field by id.
        replaceFields: [],

        // user roles
        roles: {
            1: 'Administrator',
        },

        // smoothly scrolls to a field when its added to the stage
        scrollToFieldOnAdd: true,

        // shows action buttons
        showActionButtons: true,

        // sortable controls
        sortableControls: false,

        // sticky controls
        stickyControls: {
            enable: true,
            offset: {
                top: 5,
                bottom: 'auto',
                right: 'auto',
            },
        },

        // defines new types to be used with field base types such as button and input
        subtypes: {},

        // defines a custom output for new or existing fields.
        templates: {},

        // defines custom attributes for field types
        typeUserAttrs: {},

        // disabled attributes for specific field types
        typeUserDisabledAttrs: {},

        // adds functionality to existing and custom attributes using onclone and onadd events. Events return JavaScript DOM elements.
        typeUserEvents: {},
    }
    $('.build-wrap').formBuilder(options)
});