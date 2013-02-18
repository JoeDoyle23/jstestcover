var CatalogDetail = {
    initialize: function (options) {
        this.rootFolder = options.rootFolder || '';

        ko.validation.init({
            errorClass: 'alert alert-error',
            registerExtenders: true,
            messagesOnModified: true,
            insertMessages: false,
            parseInputAttributes: false,
            messageTemplate: null,
            decorateElement: true,
            errorElementClass: 'validationError',
            grouping: { deep: true }
        });

        ko.validation.registerExtenders();

        window.viewModel = new CatalogDetailViewModel(options.model);
        ko.applyBindings(window.viewModel);

        $("#scheduledActivationDate").datepicker();
        $('#newBookModal').modal({
            show: false
        });

        $('#newBookModal').on('shown', function() {
            $('#inputCategory1Value').focus();
        });
    },

    showNewBookModal: function () {
        $('#newBookModal').modal('show');
    },

    closeNewBookModal: function () {
        $('#newBookModal').modal('hide');
    }
};

var BookViewModel = function (data) {
    var model = ko.mapping.fromJS(data);

    if (data.Category1Value === null)
        model.Category1Value('');
    
    model.Category1Value.extend({ required: { message: "The first column must have a value"} });

    return model;
};

var CatalogDetailViewModel = function (initialModel) {
    var bookMappingOptions = {
        'Books': {
            create: function (options) {
                return new BookViewModel(options.data);
            }
        }
    };

    initialModel.Catalog.ScheduledActiveDate = initialModel.Catalog.ScheduledActiveDateString;
    var model = ko.mapping.fromJS(initialModel, bookMappingOptions);

    model.newBook = ko.observable();
    model.showScheduledActivationDate = ko.observable(!model.Catalog.IsActive());
    model.showSchools = ko.observable(model.Catalog.Type() === 'Textbook' && !model.SchoolInSession());

    model.Catalog.IsActive.subscribe(function (newValue) {
        model.showScheduledActivationDate(!newValue);
    });

    model.Catalog.Type.subscribe(function (newValue) {
        model.showSchools(newValue === 'Textbook' && !model.SchoolInSession());
    });

    model.saveCatalog = function () {
        if (model.errors().length > 0) {
            model.errors.showAllMessages();
            model.errorMessages(model.errors().unique());
            return;
        }

        var catalogData = JSON.stringify({
            viewModel: ko.mapping.toJS(model)
        });

        $.jsonpost(CatalogDetail.rootFolder + 'APIs/Kentico.aspx/SaveUpdatedCatalog', catalogData)
            .done(function () {
                window.location = CatalogDetail.rootFolder + 'CatalogManagement/Catalog-List';
            })
            .fail(function () {
                alert('Error saving catalog updates.');
            });
    };

    model.showAddNewBook = function () {
        var catalogId = JSON.stringify({
            catalogId: ko.mapping.toJS(model.Catalog.Id())
        });

        $.jsonpost(CatalogDetail.rootFolder + 'APIs/Kentico.aspx/GetNewBook', catalogId)
            .done(function (response) {
                model.newBook(new BookViewModel(response.d));
                CatalogDetail.showNewBookModal();
                model.populateVisibleBooks();
            })
            .fail(function () {
                alert('Error creating new book.');
            });
    };

    model.addNewBook = function () {
        if (model.newBook().Category1Value() === '') {
            return;
        }
        model.Catalog.Books.push(model.newBook());
        CatalogDetail.closeNewBookModal();
        model.populateVisibleBooks();
    };

    model.removeBook = function (book) {
        var result = confirm("Are you sure you would like to delete this book?");
        if (!result) {
            return;
        }

        book.Category1Value.extend({ required: false });
        book.Category1Value('a');
        model.Catalog.Books.remove(book);
        model.DeletedBooks.push(book);

        model.errors.showAllMessages();
        model.errorMessages(model.errors().unique());

        model.currentPage(0);
        model.populateVisibleBooks();
    };

    model.visibleBooks = ko.observableArray([]);
    model.currentPage = ko.observable(0);
    model.itemsPerPage = ko.observable(10);


    model.totalPages = ko.computed(function () {
        return Math.ceil(model.Catalog.Books().length / model.itemsPerPage());
    });

    model.nextPage = function () {
        if (model.currentPage() === model.totalPages() - 1)
            return;

        model.currentPage(model.currentPage() + 1);
    };

    model.previousPage = function () {
        if (model.currentPage() === 0)
            return;

        model.currentPage(model.currentPage() - 1);
    };

    model.currentPage.subscribe(function (newValue) {
        model.populateVisibleBooks();
    });

    model.itemsPerPage.subscribe(function (newValue) {
        model.currentPage(0);
        model.populateVisibleBooks();
    });

    model.populateVisibleBooks = function () {
        var startIndex = model.currentPage() * model.itemsPerPage();
        var endIndex = startIndex + parseInt(model.itemsPerPage(), 10);
        model.visibleBooks(model.Catalog.Books().slice(startIndex, endIndex));
    };

    var isTextbook = function () {
        return model.Catalog.Type() === 'Textbook';
    };

    model.Catalog.Name.extend({ required: { message: "You must provide the name of the catalog"} });
    model.Catalog.SchoolId.extend({ required: { message: "You must choose a school", onlyIf: isTextbook} });
    model.errors = ko.validation.group(model);
    model.errorMessages = ko.observableArray([]);

    model.populateVisibleBooks();

    return model;
};

//Catalog editing helpers
Array.prototype.unique = function () { var o = {}, i, l = this.length, r = []; for (i = 0; i < l; i += 1) o[this[i]] = this[i]; for (i in o) r.push(o[i]); return r; };

function toTitleCase(str) {
    return str.replace(/(?:^|\s)\w/g, function (match) {
        return match.toUpperCase();
    });
}