if (typeof _yuitest_coverage == "undefined"){
    _yuitest_coverage = {};
    _yuitest_coverline = function(src, line){
        var coverage = _yuitest_coverage[src];
        if (!coverage.lines[line]){
            coverage.calledLines++;
        }
        coverage.lines[line]++;
    };
    _yuitest_coverfunc = function(src, name, line){
        var coverage = _yuitest_coverage[src],
            funcId = name + ":" + line;
        if (!coverage.functions[funcId]){
            coverage.calledFunctions++;
        }
        coverage.functions[funcId]++;
    };
}
_yuitest_coverage["C:\Personal\ncoverjs\src\CatalogDetails.js"] = {
    lines: {},
    functions: {},
    coveredLines: 0,
    calledLines: 0,
    coveredFunctions: 0,
    calledFunctions: 0,
    path: "",
    code: []
};
_yuitest_coverage["C:\Personal\ncoverjs\src\CatalogDetails.js"].code=["var CatalogDetail = {","    initialize: function (options) {","        this.rootFolder = options.rootFolder || '';","","        ko.validation.init({","            errorClass: 'alert alert-error',","            registerExtenders: true,","            messagesOnModified: true,","            insertMessages: false,","            parseInputAttributes: false,","            messageTemplate: null,","            decorateElement: true,","            errorElementClass: 'validationError',","            grouping: { deep: true }","        });","","        ko.validation.registerExtenders();","","        window.viewModel = new CatalogDetailViewModel(options.model);","        ko.applyBindings(window.viewModel);","","        $(\"#scheduledActivationDate\").datepicker();","        $('#newBookModal').modal({","            show: false","        });","","        $('#newBookModal').on('shown', function() {","            $('#inputCategory1Value').focus();","        });","    },","","    showNewBookModal: function () {","        $('#newBookModal').modal('show');","    },","","    closeNewBookModal: function () {","        $('#newBookModal').modal('hide');","    }","};","","var BookViewModel = function (data) {","    var model = ko.mapping.fromJS(data);","","    if (data.Category1Value === null)","        model.Category1Value('');","    ","    model.Category1Value.extend({ required: { message: \"The first column must have a value\"} });","","    return model;","};","","var CatalogDetailViewModel = function (initialModel) {","    var bookMappingOptions = {","        'Books': {","            create: function (options) {","                return new BookViewModel(options.data);","            }","        }","    };","","    initialModel.Catalog.ScheduledActiveDate = initialModel.Catalog.ScheduledActiveDateString;","    var model = ko.mapping.fromJS(initialModel, bookMappingOptions);","","    model.newBook = ko.observable();","    model.showScheduledActivationDate = ko.observable(!model.Catalog.IsActive());","    model.showSchools = ko.observable(model.Catalog.Type() === 'Textbook' && !model.SchoolInSession());","","    model.Catalog.IsActive.subscribe(function (newValue) {","        model.showScheduledActivationDate(!newValue);","    });","","    model.Catalog.Type.subscribe(function (newValue) {","        model.showSchools(newValue === 'Textbook' && !model.SchoolInSession());","    });","","    model.saveCatalog = function () {","        if (model.errors().length > 0) {","            model.errors.showAllMessages();","            model.errorMessages(model.errors().unique());","            return;","        }","","        var catalogData = JSON.stringify({","            viewModel: ko.mapping.toJS(model)","        });","","        $.jsonpost(CatalogDetail.rootFolder + 'APIs/Kentico.aspx/SaveUpdatedCatalog', catalogData)","            .done(function () {","                window.location = CatalogDetail.rootFolder + 'CatalogManagement/Catalog-List';","            })","            .fail(function () {","                alert('Error saving catalog updates.');","            });","    };","","    model.showAddNewBook = function () {","        var catalogId = JSON.stringify({","            catalogId: ko.mapping.toJS(model.Catalog.Id())","        });","","        $.jsonpost(CatalogDetail.rootFolder + 'APIs/Kentico.aspx/GetNewBook', catalogId)","            .done(function (response) {","                model.newBook(new BookViewModel(response.d));","                CatalogDetail.showNewBookModal();","                model.populateVisibleBooks();","            })","            .fail(function () {","                alert('Error creating new book.');","            });","    };","","    model.addNewBook = function () {","        if (model.newBook().Category1Value() === '') {","            return;","        }","        model.Catalog.Books.push(model.newBook());","        CatalogDetail.closeNewBookModal();","        model.populateVisibleBooks();","    };","","    model.removeBook = function (book) {","        var result = confirm(\"Are you sure you would like to delete this book?\");","        if (!result) {","            return;","        }","","        book.Category1Value.extend({ required: false });","        book.Category1Value('a');","        model.Catalog.Books.remove(book);","        model.DeletedBooks.push(book);","","        model.errors.showAllMessages();","        model.errorMessages(model.errors().unique());","","        model.currentPage(0);","        model.populateVisibleBooks();","    };","","    model.visibleBooks = ko.observableArray([]);","    model.currentPage = ko.observable(0);","    model.itemsPerPage = ko.observable(10);","","","    model.totalPages = ko.computed(function () {","        return Math.ceil(model.Catalog.Books().length / model.itemsPerPage());","    });","","    model.nextPage = function () {","        if (model.currentPage() === model.totalPages() - 1)","            return;","","        model.currentPage(model.currentPage() + 1);","    };","","    model.previousPage = function () {","        if (model.currentPage() === 0)","            return;","","        model.currentPage(model.currentPage() - 1);","    };","","    model.currentPage.subscribe(function (newValue) {","        model.populateVisibleBooks();","    });","","    model.itemsPerPage.subscribe(function (newValue) {","        model.currentPage(0);","        model.populateVisibleBooks();","    });","","    model.populateVisibleBooks = function () {","        var startIndex = model.currentPage() * model.itemsPerPage();","        var endIndex = startIndex + parseInt(model.itemsPerPage(), 10);","        model.visibleBooks(model.Catalog.Books().slice(startIndex, endIndex));","    };","","    var isTextbook = function () {","        return model.Catalog.Type() === 'Textbook';","    };","","    model.Catalog.Name.extend({ required: { message: \"You must provide the name of the catalog\"} });","    model.Catalog.SchoolId.extend({ required: { message: \"You must choose a school\", onlyIf: isTextbook} });","    model.errors = ko.validation.group(model);","    model.errorMessages = ko.observableArray([]);","","    model.populateVisibleBooks();","","    return model;","};","","//Catalog editing helpers","Array.prototype.unique = function () { var o = {}, i, l = this.length, r = []; for (i = 0; i < l; i += 1) o[this[i]] = this[i]; for (i in o) r.push(o[i]); return r; };","","function toTitleCase(str) {","    return str.replace(/(?:^|\\s)\\w/g, function (match) {","        return match.toUpperCase();","    });","}"];
_yuitest_coverage["C:\Personal\ncoverjs\src\CatalogDetails.js"].lines = {"1":0,"3":0,"5":0,"17":0,"19":0,"20":0,"22":0,"23":0,"27":0,"28":0,"33":0,"37":0,"41":0,"42":0,"44":0,"45":0,"47":0,"49":0,"52":0,"53":0,"56":0,"61":0,"62":0,"64":0,"65":0,"66":0,"68":0,"69":0,"72":0,"73":0,"76":0,"77":0,"78":0,"79":0,"80":0,"83":0,"87":0,"89":0,"92":0,"96":0,"97":0,"101":0,"103":0,"104":0,"105":0,"108":0,"112":0,"113":0,"114":0,"116":0,"117":0,"118":0,"121":0,"122":0,"123":0,"124":0,"127":0,"128":0,"129":0,"130":0,"132":0,"133":0,"135":0,"136":0,"139":0,"140":0,"141":0,"144":0,"145":0,"148":0,"149":0,"150":0,"152":0,"155":0,"156":0,"157":0,"159":0,"162":0,"163":0,"166":0,"167":0,"168":0,"171":0,"172":0,"173":0,"174":0,"177":0,"178":0,"181":0,"182":0,"183":0,"184":0,"186":0,"188":0,"192":0,"194":0,"195":0,"196":0};
_yuitest_coverage["C:\Personal\ncoverjs\src\CatalogDetails.js"].functions = {"(anonymous 1):27":0,"initialize:2":0,"showNewBookModal:32":0,"closeNewBookModal:36":0,"BookViewModel:41":0,"create:55":0,"(anonymous 2):68":0,"(anonymous 3):72":0,"(anonymous 4):88":0,"(anonymous 5):91":0,"saveCatalog:76":0,"(anonymous 6):102":0,"(anonymous 7):107":0,"showAddNewBook:96":0,"addNewBook:112":0,"removeBook:121":0,"nextPage:148":0,"previousPage:155":0,"(anonymous 9):162":0,"(anonymous 10):166":0,"populateVisibleBooks:171":0,"isTextbook:177":0,"(anonymous 8):144":0,"unique:192":0,"(anonymous 11):195":0,"toTitleCase:194":0,"CatalogDetailViewModel:52":0};
_yuitest_coverage["C:\Personal\ncoverjs\src\CatalogDetails.js"].coveredLines = 98;
_yuitest_coverage["C:\Personal\ncoverjs\src\CatalogDetails.js"].coveredFunctions = 27;
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 1);
var CatalogDetail = {
    initialize: function (options) {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "initialize", 2);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 3);
this.rootFolder = options.rootFolder || '';

        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 5);
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

        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 17);
ko.validation.registerExtenders();

        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 19);
window.viewModel = new CatalogDetailViewModel(options.model);
        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 20);
ko.applyBindings(window.viewModel);

        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 22);
$("#scheduledActivationDate").datepicker();
        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 23);
$('#newBookModal').modal({
            show: false
        });

        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 27);
$('#newBookModal').on('shown', function() {
            _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "(anonymous 1)", 27);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 28);
$('#inputCategory1Value').focus();
        });
    },

    showNewBookModal: function () {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "showNewBookModal", 32);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 33);
$('#newBookModal').modal('show');
    },

    closeNewBookModal: function () {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "closeNewBookModal", 36);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 37);
$('#newBookModal').modal('hide');
    }
};

_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 41);
var BookViewModel = function (data) {
    _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "BookViewModel", 41);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 42);
var model = ko.mapping.fromJS(data);

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 44);
if (data.Category1Value === null)
        {_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 45);
model.Category1Value('');}
    
    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 47);
model.Category1Value.extend({ required: { message: "The first column must have a value"} });

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 49);
return model;
};

_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 52);
var CatalogDetailViewModel = function (initialModel) {
    _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "CatalogDetailViewModel", 52);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 53);
var bookMappingOptions = {
        'Books': {
            create: function (options) {
                _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "create", 55);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 56);
return new BookViewModel(options.data);
            }
        }
    };

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 61);
initialModel.Catalog.ScheduledActiveDate = initialModel.Catalog.ScheduledActiveDateString;
    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 62);
var model = ko.mapping.fromJS(initialModel, bookMappingOptions);

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 64);
model.newBook = ko.observable();
    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 65);
model.showScheduledActivationDate = ko.observable(!model.Catalog.IsActive());
    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 66);
model.showSchools = ko.observable(model.Catalog.Type() === 'Textbook' && !model.SchoolInSession());

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 68);
model.Catalog.IsActive.subscribe(function (newValue) {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "(anonymous 2)", 68);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 69);
model.showScheduledActivationDate(!newValue);
    });

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 72);
model.Catalog.Type.subscribe(function (newValue) {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "(anonymous 3)", 72);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 73);
model.showSchools(newValue === 'Textbook' && !model.SchoolInSession());
    });

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 76);
model.saveCatalog = function () {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "saveCatalog", 76);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 77);
if (model.errors().length > 0) {
            _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 78);
model.errors.showAllMessages();
            _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 79);
model.errorMessages(model.errors().unique());
            _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 80);
return;
        }

        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 83);
var catalogData = JSON.stringify({
            viewModel: ko.mapping.toJS(model)
        });

        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 87);
$.jsonpost(CatalogDetail.rootFolder + 'APIs/Kentico.aspx/SaveUpdatedCatalog', catalogData)
            .done(function () {
                _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "(anonymous 4)", 88);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 89);
window.location = CatalogDetail.rootFolder + 'CatalogManagement/Catalog-List';
            })
            .fail(function () {
                _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "(anonymous 5)", 91);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 92);
alert('Error saving catalog updates.');
            });
    };

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 96);
model.showAddNewBook = function () {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "showAddNewBook", 96);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 97);
var catalogId = JSON.stringify({
            catalogId: ko.mapping.toJS(model.Catalog.Id())
        });

        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 101);
$.jsonpost(CatalogDetail.rootFolder + 'APIs/Kentico.aspx/GetNewBook', catalogId)
            .done(function (response) {
                _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "(anonymous 6)", 102);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 103);
model.newBook(new BookViewModel(response.d));
                _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 104);
CatalogDetail.showNewBookModal();
                _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 105);
model.populateVisibleBooks();
            })
            .fail(function () {
                _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "(anonymous 7)", 107);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 108);
alert('Error creating new book.');
            });
    };

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 112);
model.addNewBook = function () {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "addNewBook", 112);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 113);
if (model.newBook().Category1Value() === '') {
            _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 114);
return;
        }
        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 116);
model.Catalog.Books.push(model.newBook());
        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 117);
CatalogDetail.closeNewBookModal();
        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 118);
model.populateVisibleBooks();
    };

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 121);
model.removeBook = function (book) {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "removeBook", 121);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 122);
var result = confirm("Are you sure you would like to delete this book?");
        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 123);
if (!result) {
            _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 124);
return;
        }

        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 127);
book.Category1Value.extend({ required: false });
        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 128);
book.Category1Value('a');
        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 129);
model.Catalog.Books.remove(book);
        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 130);
model.DeletedBooks.push(book);

        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 132);
model.errors.showAllMessages();
        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 133);
model.errorMessages(model.errors().unique());

        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 135);
model.currentPage(0);
        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 136);
model.populateVisibleBooks();
    };

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 139);
model.visibleBooks = ko.observableArray([]);
    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 140);
model.currentPage = ko.observable(0);
    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 141);
model.itemsPerPage = ko.observable(10);


    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 144);
model.totalPages = ko.computed(function () {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "(anonymous 8)", 144);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 145);
return Math.ceil(model.Catalog.Books().length     });

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 148);
model.nextPage = function () {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "nextPage", 148);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 149);
if (model.currentPage() === model.totalPages() - 1)
            {_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 150);
return;}

        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 152);
model.currentPage(model.currentPage() + 1);
    };

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 155);
model.previousPage = function () {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "previousPage", 155);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 156);
if (model.currentPage() === 0)
            {_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 157);
return;}

        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 159);
model.currentPage(model.currentPage() - 1);
    };

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 162);
model.currentPage.subscribe(function (newValue) {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "(anonymous 9)", 162);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 163);
model.populateVisibleBooks();
    });

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 166);
model.itemsPerPage.subscribe(function (newValue) {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "(anonymous 10)", 166);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 167);
model.currentPage(0);
        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 168);
model.populateVisibleBooks();
    });

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 171);
model.populateVisibleBooks = function () {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "populateVisibleBooks", 171);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 172);
var startIndex = model.currentPage() * model.itemsPerPage();
        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 173);
var endIndex = startIndex + parseInt(model.itemsPerPage(), 10);
        _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 174);
model.visibleBooks(model.Catalog.Books().slice(startIndex, endIndex));
    };

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 177);
var isTextbook = function () {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "isTextbook", 177);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 178);
return model.Catalog.Type() === 'Textbook';
    };

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 181);
model.Catalog.Name.extend({ required: { message: "You must provide the name of the catalog"} });
    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 182);
model.Catalog.SchoolId.extend({ required: { message: "You must choose a school", onlyIf: isTextbook} });
    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 183);
model.errors = ko.validation.group(model);
    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 184);
model.errorMessages = ko.observableArray([]);

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 186);
model.populateVisibleBooks();

    _yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 188);
return model;
};

//Catalog editing helpers
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 192);
Array.prototype.unique = function () { _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "unique", 192);
var o = {}, i, l = this.length, r = []; for (i = 0; i < l; i += 1) {o[this[i]] = this[i];} for (i in o) {r.push(o[i]);} return r; };

_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 194);
function toTitleCase(str) {
    _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "toTitleCase", 194);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 195);
return str.replace(/(?:^|\s)\w/g, function (match) {
        _yuitest_coverfunc("C:\Personal\ncoverjs\src\CatalogDetails.js", "(anonymous 11)", 195);
_yuitest_coverline("C:\Personal\ncoverjs\src\CatalogDetails.js", 196);
return match.toUpperCase();
    });
}
