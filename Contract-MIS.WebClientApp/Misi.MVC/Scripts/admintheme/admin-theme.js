var reference = false;

$(document).ready(function() {

    /* modify datatable control inputs */
    // tableWrapper.find('.dataTables_length select').select2(); // initialize select2 dropdown

    /* Add event listener for opening and closing details
     * Note that the indicator for showing which row is open is not controlled by DataTables,
     * rather it is done here
     */
    // table.on('click', ' tbody td .row-details', function () {
    //     var nTr = $(this).parents('tr')[0];
    //     if (oTable.fnIsOpen(nTr)) {
    //         /* This row is already open - close it */
    //         $(this).addClass("row-details-close").removeClass("row-details-open");
    //         oTable.fnClose(nTr);
    //     } else {
    //         /* Open this row */
    //         $(this).addClass("row-details-open").removeClass("row-details-close");
    //         oTable.fnOpen(nTr, fnFormatDetails(oTable, nTr), 'details');
    //     }
    // });

// datatable init

    if ($(".datepicker").length > 0) {
        // $(".datepicker").datepicker({
        // format: 'dd-mm-yy'
        // });
        $('.datepicker').datepicker({ format: 'dd-mm-yyyy', autoclose: true });
        var nowDate = new Date();
        nowDate.setDate(nowDate.getDate());
        $(".datepicker").datepicker("setDate", nowDate);
        $(".datepicker").datepicker('update');
    }

    $('body').on('click', '.dropdown-menu.hold-on-click', function(e) {
        e.stopPropagation();
    });

    $('.toggle-menu').on('click', function() {
        $('body').toggleClass('page-sidebar-closed');
    })


// handle panel fullscreen
    $('body').on('click', '.panel > .panel-heading > .actions  .fullscreen', function(e) {
        e.preventDefault();
        var panel = $(this).closest(".panel");

        //panel.attr('data', 'tester');
        if (panel.hasClass('panel-fullscreen')) {

            $(this).removeClass('on').find("i").removeClass("icon-resize-small").addClass("icon-resize-full");
            panel.removeClass('panel-fullscreen').parent().removeClass('panel-fullscreen');
            $('body').removeClass('page-panel-fullscreen');

        } else {
            $(this).addClass('on').find("i").removeClass("icon-resize-full").addClass("icon-resize-small");
            panel.addClass('panel-fullscreen').parent().addClass('panel-fullscreen');
            $('body').addClass('page-panel-fullscreen');

        }
    });


    //set main navigation aside
    /* global employee_token */
    function navSidebar() {
        var sidebar = $('#nav-sidebar'),
            header = $("#header");
        sidebar.off();
        $('.expanded').removeClass('expanded');
        $('.maintab').not('.active').closest('.submenu').hide();
        sidebar.on('click', '.submenu_expand', function() {
            var $navId = $(this).parent();
            $('.submenu-collapse').remove();
            if ($('.expanded').length) {
                $('.expanded > ul').slideUp('fast', function() {
                    var $target = $('.expanded');
                    $target.removeClass('expanded');
                    $($navId).not($target).not('.active').addClass('expanded');
                    $($navId).not($target).not('.active').children('ul:first').hide().slideDown();
                });
            } else {
                $($navId).not('.active').addClass('expanded');
                $($navId).not('.active').children('ul:first').hide().slideDown();
            }
        });
        //sidebar menu collapse
        sidebar.find('.menu-collapse').on('click', function() {
            $('body').toggleClass('page-sidebar-closed');
            $('.expanded').removeClass('expanded');
            $.ajax({
                url: "index.php",
                cache: false,
                data: "token=" + employee_token + '&ajax=1&action=toggleMenu&tab=AdminEmployees&collapse=' + Number($('body').hasClass('page-sidebar-closed'))
            });
        });
    }

    function navTopbarReset() {
        ellipsed = [];
        $('#ellipsistab').remove();
        $('#nav-topbar ul.menu').find('li.maintab').each(function() {
            $(this).removeClass('hide');
        });
    }

    //agregate out of bounds items from top menu into ellipsis dropdown
    function navTopbarEllipsis() {
        navTopbarReset();
        $('#nav-topbar ul.menu').find('li.maintab').each(function() {
            if ($(this).position().top > 0) {
                ellipsed.push($(this).html());
                $(this).addClass('hide');
            }
        });
        if (ellipsed.length > 0) {
            $('#nav-topbar ul.menu').append('<li id="ellipsistab" class="subtab has_submenu"><a href="#"><i class="icon-ellipsis-horizontal"></i></a><ul id="ellipsis_submenu" class="submenu"></ul></li>');
            for (var i = 0; i < ellipsed.length; i++) {
                $('#ellipsis_submenu').append('<li class="subtab has_submenu">' + ellipsed[i] + '</li>');
            }
        }
    }

    //set main navigation on top
    function navTopbar() {
        navTopbarReset();
        $('#nav-sidebar').attr('id', 'nav-topbar');
        var topbar = $('#nav-topbar');
        topbar.off();
        $('span.submenu_expand').remove();
        $('.expanded').removeClass('expanded');
        // expand elements with submenu
        topbar.on('mouseenter', 'li.has_submenu', function() {
            $(this).addClass('expanded');
        });
        topbar.on('mouseleave', 'li.has_submenu', function() {
            $(this).removeClass('expanded');
        });
        // hide element over menu width on load
        navTopbarEllipsis();
        //hide element over menu width on resize
        $(window).on('resize', function() {
            navTopbarEllipsis();
        });
    }

    //set main navigation for mobile devices
    function mobileNav() {
        navTopbarReset();
        // clean actual menu type
        // get it in navigation whatever type it is
        var navigation = $('#nav-sidebar, #nav-topbar, #navbar-header');
        navigation.find('.menu').hide();
        var submenu = "";
        // clean trigger
        navigation.off().attr('id', 'nav-mobile');
        $('span.menu-collapse').off();
        navigation.on('click.collapse', 'span.menu-collapse', function() {
            if ($(this).hasClass('expanded')) {
                $(this).html('<i class="icon-align-justify"></i>');
                navigation.find('ul.menu').hide();
                navigation.removeClass('expanded');
                $(this).removeClass('expanded');
                //remove submenu when closing nav
                $('#nav-mobile-submenu').remove();
            } else {
                $(this).html('<i class="icon-remove"></i>');
                navigation.find('ul.menu').removeClass('menu-close').show();
                navigation.find('.icon-chevron-right').removeClass('hide');
                navigation.addClass('expanded');
                $(this).addClass('expanded');
            }
        });
        //get click for item which has submenu
        navigation.on('click.submenu', '.maintab.has_submenu a.title', function(e) {
            e.preventDefault();
            navigation.find('.menu').addClass('menu-close');
            $('#nav-mobile-submenu').remove();
            navigation.find('.icon-chevron-right').addClass('hide');

            //create submenu
            submenu = $('<ul id="nav-mobile-submenu" class="menu"><li><a href="#" id="nav-mobile-submenu-back"><i class="icon-arrow-left"></i>' + $(this).html() + '</a></li></ul>');
            submenu.append($(this).closest('.maintab').find('.submenu').html());
            //show submenu
            navigation.append(submenu);
            submenu.show();
        });
        navigation.on('click.back', '#nav-mobile-submenu-back', function(e) {
            e.preventDefault();
            submenu.remove();
            navigation.find('.menu').removeClass('menu-close').show();
            navigation.find('.icon-chevron-right').removeClass('hide');
        });
    }

    //unset mobile nav
    function removeMobileNav() {
        var navigation = $('#nav-mobile');
        $('#nav-mobile-submenu').remove();
        $('span.menu-collapse').html('<i class="icon-align-justify"></i>');
        navigation.off();
        if ($('body').hasClass('page-sidebar')) {
            navigation.attr('id', "nav-sidebar");
            navSidebar();
        } else if ($('body').hasClass('page-topbar')) {
            navigation.attr('id', "nav-topbar");
            navTopbar();
        }
        navigation.find('.menu').show();
    }

    //init main navigation
    function initNav() {
        if ($('body').hasClass('page-sidebar')) {
            navSidebar();
        } else if ($('body').hasClass('page-topbar')) {
            navTopbar();
        }
    }

    //show footer when reach bottom
    function animateFooter() {
        if ($(window).scrollTop() + $(window).height() === $(document).height()) {
            $('#footer:hidden').removeClass('hide');
        } else {
            $('#footer').addClass('hide');
        }
    }

    //scroll top
    function animateGoTop() {
        if ($(window).scrollTop()) {
            $('#go-top:hidden').stop(true, true).fadeIn();
            $('#go-top:hidden').removeClass('hide');
        } else {
            $('#go-top').stop(true, true).fadeOut();
        }
    }

    var ellipsed = [];
    initNav();

    // prevent mouseout + direct path to submenu on sidebar uncollapsed navigation + avoid out of bounds
    var closingMenu, openingMenu;
    $('li.maintab.has_submenu').hover(function() {
        var submenu = $(this);
        if (submenu.is('.active') && submenu.children('ul.submenu').is(':visible')) {
            return;
        }
        clearTimeout(openingMenu);
        clearTimeout(closingMenu);
        openingMenu = setTimeout(function() {
            $('li.maintab').removeClass('hover');
            $('ul.submenu.outOfBounds').removeClass('outOfBounds').css('top', 0);
            submenu.addClass('hover');
            var h = $(window).height();
            var x = submenu.find('.submenu li').last().offset();
            var l = x.top + submenu.find('.submenu li').last().height();
            var f = 25;
            if ($('#footer').is(':visible')) {
                f = $('#footer').height() + f;
            }
            var s = $(document).scrollTop();
            var position = h - l - f + s;
            var out = false;
            if (position < 0) {
                out = true;
                submenu.find('.submenu').addClass('outOfBounds').css('top', position);
            }
        }, 50);
    }, function() {
        var submenu = $(this);
        closingMenu = setTimeout(function() {
            submenu.removeClass('hover');
        }, 250);
    });

    $('ul.submenu').on('mouseenter', function() {
        clearTimeout(openingMenu);
    });

    //media queries - depends of enquire.js
    /*global enquire*/
    enquire.register('screen and (max-width: 1200px)', {
        match: function() {
            if ($('#main').hasClass('helpOpen')) {
                $('.toolbarBox a.btn-help').trigger('click');
            }
        },
        unmatch: function() {

        }
    });
    enquire.register('screen and (max-width: 768px)', {
        match: function() {

            $('body.page-sidebar').addClass('page-sidebar-closed');
        },
        unmatch: function() {
            $('body.page-sidebar').removeClass('page-sidebar-closed');
        }
    });
    enquire.register('screen and (max-width: 480px)', {
        match: function() {
            $('body').addClass('mobile-nav');
            mobileNav();
        },
        unmatch: function() {
            $('body').removeClass('mobile-nav');
            removeMobileNav();
        }
    });

    //bootstrap components init
    if ($(".dropdown-toggle").length > 0)
        $('.dropdown-toggle').dropdown();

    if ($(".label-tooltip, .help-tooltip").length > 0)
        $('.label-tooltip, .help-tooltip').tooltip();
    if ($(".textarea-autosize").length > 0)
        $('.textarea-autosize').autosize();
    $('input[type=checkbox]').uniform();

    //init footer
    animateFooter();

    // go on top of the page
    $('#go-top').on('click', function() {
        $('html, body').animate({ scrollTop: 0 }, 'slow');
        return false;
    });

    var timer;
    $(window).scroll(function() {
        if (timer) {
            window.clearTimeout(timer);
        }
        timer = window.setTimeout(function() {
            animateGoTop();
            animateFooter();
        }, 100);
    });

    // search with nav sidebar closed
    $(document).on('click', '.page-sidebar-closed .searchtab', function() {
        $(this).addClass('search-expanded');
        $(this).find('#bo_query').focus();
    });

    $('.page-sidebar-closed').click(function() {
        $('.searchtab').removeClass('search-expanded');
    });

    $('#header_search button').on('click', function(e) {
        e.stopPropagation();
    });

    //erase button search input
    if ($('#bo_query').val() !== '') {
        $('.clear_search').removeClass('hide');
    }

    $('.clear_search').on('click', function(e) {
        e.stopPropagation();
        e.preventDefault();
        var id = $(this).closest('form').attr('id');
        $('#' + id + ' #bo_query').val('').focus();
        $('#' + id + ' .clear_search').addClass('hide');
    });
    $('#bo_query').on('keydown', function() {
        if ($('#bo_query').val() !== '') {
            $('.clear_search').removeClass('hide');
        }
    });

    //search with nav sidebar opened
    $('.page-sidebar').click(function() {
        $('#header_search .form-group').removeClass('focus-search');
    });

    $('#header_search #bo_query').on('click', function(e) {
        e.stopPropagation();
        e.preventDefault();
        if ($('body').hasClass('mobile-nav')) {
            return false;
        }
        $('#header_search .form-group').addClass('focus-search');
    });

    //select list for search type
    $('#header_search_options').on('click', 'li a', function(e) {
        e.preventDefault();
        $('#header_search_options .search-option').removeClass('active');
        $(this).closest('li').addClass('active');
        $('#bo_search_type').val($(this).data('value'));
        $('#search_type_icon').removeAttr("class").addClass($(this).data('icon'));
        $('#bo_query').attr("placeholder", $(this).data('placeholder'));
        $('#bo_query').focus();
    });


//scroll_if_anchor(window.location.hash);

    $("body").on("click", "a.anchor", scroll_if_anchor);

    // open / hide menu
//	var effect = "effect-3";
//	$('#header_toggle_menu').on("click", function(){
//			
//			if ($("#main").hasClass('menu-open')) {
//				$("#main").removeClass(effect);
//				setTimeout( function() {
//					$("#main").removeClass('menu-open');
//					//resetDrillDown();
//				}, 25 );
//								
//			} else {
//				$("#main").addClass(effect);
//				setTimeout( function() {
//					$("#main").addClass('menu-open');
//				}, 25 );
//			}
//	});

    $('.panel .show_hide').on("click", function() {
        var el = $(this).closest(".panel").children(".panel-body");

        if ($(this).closest(".panel").find('.panel-footer').length > 0)
            var el_footer = $(this).closest(".panel").children(".panel-footer");

        if (el.is(":visible")) {
            $(this).find("i").removeClass("icon-chevron-down").addClass("icon-chevron-up");
            el.slideUp(200);
            if ($(this).closest(".panel").find('.panel-footer').length > 0)
                el_footer.slideUp(200);
        } else {
            $(this).find("i").removeClass("icon-chevron-up").addClass("icon-chevron-down");
            el.slideDown(200);
            if ($(this).closest(".panel").find('.panel-footer').length > 0)
                el_footer.slideDown(200);
        }
    });


    $("#Scenarios_PostData").change(function() {
        var $this = $("#Scenarios_PostData option:selected"),
            $value = $this.val(),
            $str_issued_by = $("#IssuedByListItems_PostData");

        //alert( $(".toggle-radio").val() );
        //alert("reference awal=" + reference);

        // selain transfer asset && broken create automation di set NO
        if ($value != 'Transfer Asset' && $value != 'Broken') {
            $(".event-switch").find('input').attr('data', 'test');
            //alert(1);
            $(".event-switch").find('input').removeAttr('checked');
            $(".event-switch").find('input#reference_off').prop('checked', 'true');
            reference = false;
        } else {
            //alert(2);
            $(".event-switch").find('input').removeAttr('checked');
            $(".event-switch").find('input#reference_on').prop('checked', 'true');
            reference = true;
        }
        //alert("reference akhir=" + reference);
        // if ( $value == '')
        // 	$("#IssuedByListItems_PostData").val($value);
        chainingStr($value, $str_issued_by);


    }).trigger("change");


    $(".toggle-radio").change(function() {
        var $switch = $(this).find('input');
        var $Scenarios_PostData = $("#Scenarios_PostData option:selected"),
            $Scenarios_PostData_value = $Scenarios_PostData.val(),
            $str_issued_by = $("#IssuedByListItems_PostData");

        //$(this).find('input:not(:checked)').removeAttr('checked');

        //$(this).find('input:checked').attr('checked','checked');
        //$(this).find('input:checked').prop('checked','true');
        //alert(this.value);
        if (this.value == 0) {
            $('#wrapper_service').hide();
            $('#wrapper_ticket').hide();
            $('#wrapper_notification').hide();
            $(".event-switch").find('input').removeAttr('checked');
            $(".event-switch").find('input#reference_off').prop('checked', 'true');
            reference = false;
        } else {
            reference = true;
            $(".event-switch").find('input').removeAttr('checked');
            $(".event-switch").find('input#reference_on').prop('checked', 'true');
            //$("#Scenarios_PostData").trigger( 'change' );
            chainingStr($Scenarios_PostData_value, $str_issued_by);
        }
    }); // .trigger( 'click' );

    $(".only-one-service").keyup(function() {
        $(".only-one-service").removeAttr('disabled');
        if ($(this).val().length == 0) {
            $(this).closest('div').find('.form-control-feedback').addClass('hide');
            $(".only-one-ticket").removeAttr('disabled');
            $(".only-one-notification").removeAttr('disabled');
        } else {
            $(this).closest('div').find('.form-control-feedback').removeClass('hide');
            $(".only-one-ticket").attr('disabled', 'disabled');
            $(".only-one-notification").attr('disabled', 'disabled');
        }
    });

    $(".only-one-ticket").keyup(function() {
        $(".only-one-ticket").removeAttr('disabled');
        if ($(this).val().length == 0) {
            $(this).closest('div').find('.form-control-feedback').addClass('hide');
            $(".only-one-service").removeAttr('disabled');
        } else {
            $(this).closest('div').find('.form-control-feedback').removeClass('hide');
            $(".only-one-service").attr('disabled', 'disabled');
        }
    });

    $(".only-one-notification").keyup(function() {
        $(".only-one-notification").removeAttr('disabled');
        if ($(this).val().length == 0) {
            $(this).closest('div').find('.form-control-feedback').addClass('hide');
            $(".only-one-service").removeAttr('disabled');
        } else {
            $(this).closest('div').find('.form-control-feedback').removeClass('hide');
            $(".only-one-service").attr('disabled', 'disabled');
        }
    })

    $("#wrapper_service .fa-close").on('click', function() {
        $(".only-one-service").val('');
        $(".only-one-service").keyup();
    });

    $("#wrapper_ticket .fa-close").on('click', function() {
        $(".only-one-ticket").val('');
        $(".only-one-ticket").keyup();
    });

    $("#wrapper_notification .fa-close").on('click', function() {
        $(".only-one-notification").val('');
        $(".only-one-notification").keyup();
    })


    // modal dialog pop up
    $(document).on("click", "#link-routing", function() {
        var url = $(this).attr('data-rel'),
            mod = $(this).attr('data-mod');
        alert(mod);
        // sample data
        var json = [
            {
                "name": "Tiger Nixon",
                "position": "System Architect",
                "salary": "$320,800",
                "start_date": "2011\/04\/25",
                "office": "Edinburgh",

            },
            {
                "name": "Garrett Winters",
                "position": "Accountant",
                "salary": "$170,750",
                "start_date": "2011\/07\/25",
                "office": "Tokyo",

            },
            {
                "name": "Ashton Cox",
                "position": "Junior Technical Author",
                "salary": "$86,000",
                "start_date": "2009\/01\/12",
                "office": "San Francisco",

            },
            {
                "name": "Cedric Kelly",
                "position": "Senior Javascript Developer",
                "salary": "$433,060",
                "start_date": "2012\/03\/29",
                "office": "Edinburgh",

            }
        ];

        console.log(json);
        $.each(json, function(idx, obj) {
            console.log(obj.name);
        });
        // $.ajax({
        //    type: "POST",
        //    url: base_url + 'material/search_list_material',
        //    data :value,
        //    dataType: "html",
        //    beforeSend: function() {
        //    	$('#content-routing').html('Loading data please wait ..');
        //    },
        //    success: function(data) {
        //        $('#content-routing').empty().html(data);
        //    }
        //});

        $('#modal-routing').modal();
        //   // $('#submit-accAss').attr('onclick', 'return_acc_ass(\'account_assignment/view\', \'accAss\',' + id + ')');
        //    $('#submit-mat').attr('onclick', 'return_material(\'material/view\', \'matid\',' + id_plant + ')');
    });

    // add others description
    if ($("#RoutingInfoHeadingViewModel_DeviceViewModel_DeviceList_PostData").length > 0) {
        $("#RoutingInfoHeadingViewModel_DeviceViewModel_DeviceList_PostData").change(function() {
            var value = $("#RoutingInfoHeadingViewModel_DeviceViewModel_DeviceList_PostData option:selected").val();

            if (value == "Others") {
                $(".othersDescription").removeClass('hide');
                //setTimeout(function(){ $(".othersDescription").addClass('show').focus() }, 200);
                setTimeout(function() { $(".othersDescription").show() }, 200);
            } else {
                $(".othersDescription").removeClass('show');
                //setTimeout(function(){ $(".othersDescription").addClass('hide') }, 200);
                setTimeout(function() { $(".othersDescription").hide().val('') }, 200);
            }
        }).trigger('change');
    }

    $("#tabelRouting tbody").sortable().bind('sortupdate', function(e, ui) {
        var id = 0;
        //var ids = ui.item.attr('id').replace('tr_','');
        //alert(ids);

        //var data;
        $.each(e.target.children, function(index, element) {
            $(element).find('.step').val(++id);
        });
    });


    // draft and submit
    if ($("#RunProformaInvoiceHeadingViewModel_Versions_PostData").length > 0) {
        $("#RunProformaInvoiceHeadingViewModel_Versions_PostData").change(function() {
            var value = $("#RunProformaInvoiceHeadingViewModel_Versions_PostData option:selected").val();
            if (value == "Draft") {
                $("#save").show();
                $("#submit").hide();
            } else if ( value == 'Final') {
                $("#save").hide();
                $("#submit").show();
            }
        }).trigger('change');
    }
    // draft and submit

}); //end dom ready


//move to hash after clicking on anchored links
function scroll_if_anchor(href) {
    href = typeof(href) === "string" ? href : $(this).attr("href");
    var fromTop = 120;
    if (href.indexOf("#") === 0) {
        var $target = $(href);
        if ($target.length) {
            $('html, body').animate({ scrollTop: $target.offset().top - fromTop });
            if (history && "pushState" in history) {
                history.pushState({}, document.title, window.location.pathname + href);
                return false;
            }
        }
    }
}


function displayTab(tab) {
    $('.content_tab').removeClass('active').hide().find('.content_tab_wrapper').hide();
    $('.tab-row.active').removeClass('active');
    //setTimeout( function() {
    $('#content_tab_' + tab).addClass('active').show().find('.content_tab_wrapper').show();
    //}, 25 );
    $('#tab_link_' + tab).parent().addClass('active');
    $('#currentFormTab').val(tab);
}


function chainingStr(str, replace) {
    var selected = "";

    if (str == 'Transfer Asset') {
        selected = 'Helpdesk';

        if (reference == true) {
            $("#wrapper_ticket").fadeIn();
            $("#wrapper_notification").fadeOut();
            $("#wrapper_service").fadeIn();
        } else {
            $("#wrapper_ticket").fadeOut();
            $("#wrapper_notification").fadeOut();
            $("#wrapper_service").fadeOut();
        }
    } else if (str == 'Termination') {
        selected = 'Helpdesk';
        if (reference == true) {
            $("#wrapper_ticket").fadeOut();
            $("#wrapper_notification").fadeOut();
            $("#wrapper_service").fadeIn();
        } else {
            $("#wrapper_ticket").fadeOut();
            $("#wrapper_notification").fadeOut();
            $("#wrapper_service").fadeOut();
        }
    } else if (str == 'Broken') {
        selected = 'Workshop';
        if (reference == true) {
            $("#wrapper_ticket").fadeOut();
            $("#wrapper_notification").fadeIn();
            $("#wrapper_service").fadeIn();
        } else {
            $("#wrapper_ticket").fadeOut();
            $("#wrapper_notification").fadeOut();
            $("#wrapper_service").fadeOut();
        }
    } else if (str == 'Return Device') {
        selected = 'Warehouse';
        if (reference == true) {
            $("#wrapper_ticket").fadeOut();
            $("#wrapper_notification").fadeOut();
            $("#wrapper_service").fadeIn();
        } else {
            $("#wrapper_ticket").fadeOut();
            $("#wrapper_notification").fadeOut();
            $("#wrapper_service").fadeOut();
        }
    } else {
        selected = 'Sales Admin';
        if (reference == true) {
            $("#wrapper_ticket").fadeOut();
            $("#wrapper_notification").fadeOut();
            $("#wrapper_service").fadeIn();
        } else {
            $("#wrapper_ticket").fadeOut();
            $("#wrapper_notification").fadeOut();
            $("#wrapper_service").fadeOut();
        }
    }

    replace.val(selected);
}

// Proforma Invoice


function showModalLoading() {
    $('#billing-document-modal-container').html('<center><img src="/Content/img/loading.gif" class="overlay-content" /></center>');
    //$('#billing-document-modal').modal('show');
    $('#billing-document-modal').modal({
        backdrop: 'static',
        keyboard: false
    })
}

function hideModalLoading() {
    $('#billing-document-modal').modal('hide');
}

function error_handler(e) {
    if (e.errors) {
        var message = "Errors:\n";
        $.each(e.errors, function (key, value) {
            if ('errors' in value) {
                $.each(value.errors, function () {
                    message += this + "\n";
                });
            }
        });
        alert(message);
    }
}

function makeTransparent() {

    // when displayed on GRID
    $(".k-grid-content-locked > table").find('td').each(function () {
        var $this = $(this),
            $val = $this.text();

        // equivalent to SharedResource.SpaceChar
        if ($val === '-')
            $this.addClass('transparent');
    });
}

function checkIfTransparent(e) {
    console.log("asas");
    $(".k-grid-content-locked > table").find('td').each(function () {
        if ($(this).hasClass("k-dirty-cell")) {
            var $this = $(this),
            $val = $this.text();

            // equivalent to SharedResource.SpaceChar
            if ($val === '-')
                $this.addClass('transparent');
            else
                $this.removeClass('transparent');
        }
    });
}


var validationMessageTmpl = kendo.template($("#messageBoxForGrid").html());

function error(args) {
    if (args.errors) {
        var grid = $("#BillingItemKendoGrid").data("kendoGrid");
        grid.one("dataBinding", function (e) {
            e.preventDefault();   // cancel grid rebind if error occurs                             

            for (var error in args.errors) {
                showMessage(grid.editable.element, error, args.errors[error].errors);
            }
        });
    }
}

function showMessage(container, name, errors) {
    //add the validation message to the form
    container.find("[data-valmsg-for=" + name + "],[data-val-msg-for=" + name + "]")
             .replaceWith(validationMessageTmpl({ field: name, message: errors[0] }))
}

function error_handler_proformainvoice_grid(e) {
    if (e.errors) {
        var message = "Errors:\n";
        $.each(e.errors, function (key, value) {
            if ('errors' in value) {
                $.each(value.errors, function () {
                    message += this + "\n";
                });
            }
        });
        alert(message);
    }
}

function excelExportFunction(e) {
    var sheet = e.workbook.sheets[0];
    // Refers to column.Bound(p => p.ReasonForRejectionVM).ClientTemplate("#=ReasonForRejectionVM.CategoryName#");
    var template = kendo.template(this.columns[0].template);
    var data = this.dataSource.data();
    for (var i = 0; i < data.length; i++) {
        sheet.rows[i + 1].cells[0].value = template(data[i]);
    }
}


function excelExportFunctionForAppendix(e) {
    //alert("export to excel");
    var sheet = e.workbook.sheets[0];
    // Refers to column.Bound(p => p.ReasonForRejectionVM).ClientTemplate("#=ReasonForRejectionVM.CategoryName#");
    //var data = this.dataSource.data();
    //for (var i = 0; i < data.length; i++) {
    //    sheet.rows[i + 1].cells[1].value = data[i];
    //}
}