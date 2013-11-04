<?php
/* ------------------------------ */
/* Debugging options              */
/* ------------------------------ */
error_reporting(E_ALL);
ini_set('display_errors', 'yes');

/* ------------------------------ */
/* Dynamic sidebars registartion */
/* ------------------------------ */
register_sidebar(array(
    'id' => 'sidebar-two',
    'name' => 'Main Sidebar',
));

register_sidebar(array(
    'id' => 'sidebar-outer-second',
    'name' => 'Second Outer Sidebar',
));

register_sidebar(array(
    'id' => 'sidebar-one',
    'name' => 'Inner Left Sidebar',
));

register_sidebar(array(
    'id' => 'sidebar-second-inner',
    'name' => 'Second Inner Sidebar',
));

register_sidebar(array(
    'id' => 'sidebar-bottom-left',
    'name' => 'Bottom Left Sidebar',
));

register_sidebar(array(
    'id' => 'sidebar-bottom-center',
    'name' => 'Bottom Center Sidebar',
));

register_sidebar(array(
    'id' => 'sidebar-bottom-right',
    'name' => 'Bottom Right Sidebar',
));

/* ------------------------------ */
/* Main navigation registration  */
/* ------------------------------ */
register_nav_menus(array(
    'main' => __('Main Navigation', ''),
));

/* fallback when no dynamic nav */

function fallbacknav() {
    ?>

    <ul>
        <li> Go to Adminpanel > Appearance > Menus to create your menu. 
            You should have WP 3.0+ version for custom menus to work.
        </li>
    </ul>

    <?php
}

/* ------------------------------ */
/*  Futured image support        */
/* ------------------------------ */

add_theme_support('post-thumbnails');

/* ------------------------------ */
/* Enqueing styles and scripts   */
/* ------------------------------ */

function theme_styles() {
    wp_register_style('custom-style', get_template_directory_uri() . '/style/responsive.css', array(), '20120208', 'all');
    // enqueing:
    wp_enqueue_style('custom-style');
}

add_action('wp', 'theme_styles');


/* ------------------------------ */
/* Custom admin panel             */
/* ------------------------------ */

// Theme Options
// Specky Geek -- http://www.speckygeek.com

$themename = "CMS Course project";
$shortname = "ccp";
$version = "1.0";

// Create theme options
global $options;
$options = array(
    array("name" => "General",
        "type" => "section"),
    array("type" => "open"),
    array("name" => "Custom Feed URL",
        "desc" => "You can use your own feed URL (<strong>with http://</strong>). Paste your Feedburner URL here to let readers see it in your website.",
        "id" => $shortname . "_feedurl",
        "type" => "text",
        "std" => get_bloginfo('rss2_url')),
    array("name" => "Delete Extra Feeds",
        "desc" => "WordPress adds feeds for categories, tags, etc., by default. Check this box to remove them and reduce the clutter.",
        "id" => $shortname . "_cleanfeedurls",
        "type" => "checkbox",
        "std" => ""),
    array("name" => "Twitter ID'",
        "desc" => "Your Twitter user name, please. It will be shown in the navigation bar. Leaving it blank will keep the Twitter icon supressed.",
        "id" => $shortname . "_twitterid",
        "type" => "text",
        "std" => ""),
    array("name" => "Facebook Page",
        "desc" => "Link to your Facebook page, <strong>with http://</strong>. It will be shown in the footer. Leaving it blank will keep the Facebook icon suppressed.",
        "id" => $shortname . "_facebookid",
        "type" => "text",
        "std" => ""),
    array("name" => "Google+ Page",
        "desc" => "Link to your Google+ page, <strong>with http://</strong>. It will be shown in the footer. Leaving it blank will keep the Facebook icon suppressed.",
        "id" => $shortname . "_googleplusid",
        "type" => "text",
        "std" => ""),
    array("type" => "close"),
    array("name" => "Footer",
        "type" => "section"),
    array("type" => "open"),
    array("name" => "Footer Text",
        "desc" => "Paste your text, copyright statements, etc., here.",
        "id" => $shortname . "_footer_text",
        "type" => "textarea",
        "std" => ""),
    array("type" => "close"),
);

function ccp_add_admin() {

    global $themename, $shortname, $options;

    if (isset($_GET['page']) && ( $_GET['page'] == basename(__FILE__) )) {

        if (isset($_REQUEST['action']) && ( 'save' == $_REQUEST['action'] )) {

            foreach ($options as $value) {
                if (array_key_exists('id', $value)) {
                    if (isset($_REQUEST[$value['id']])) {
                        update_option($value['id'], $_REQUEST[$value['id']]);
                    } else {
                        delete_option($value['id']);
                    }
                }
            }
            header("Location: admin.php?page=" . basename(__FILE__) . "&saved=true");
        } else if (isset($_REQUEST['action']) && ( 'reset' == $_REQUEST['action'] )) {
            foreach ($options as $value) {
                if (array_key_exists('id', $value)) {
                    delete_option($value['id']);
                }
            }
            header("Location: admin.php?page=" . basename(__FILE__) . "&reset=true");
        }
    }

    add_menu_page($themename, $themename, 'administrator', basename(__FILE__), 'ccp_admin');
    add_submenu_page(basename(__FILE__), $themename . ' Options', 'Theme Options', 'administrator', basename(__FILE__), 'ccp_admin'); // Default
}

function ccp_add_init() {

    $file_dir = get_bloginfo('template_directory');
    wp_enqueue_style("ccpCss", $file_dir . "/functions/theme-options.css", false, "1.0", "all");
    wp_enqueue_script("ccpScript", $file_dir . "/functions/theme-options.js", false, "1.0");
}

function ccp_admin() {

    global $themename, $shortname, $version, $options;
    $i = 0;

    if (isset($_REQUEST['saved']) && ($_REQUEST['saved'] ))
        echo '<div id="message" class="updated fade"><p><strong>' . $themename . ' settings saved.</strong></p></div>';
    if (isset($_REQUEST['reset']) && ($_REQUEST['reset'] ))
        echo '<div id="message" class="updated fade"><p><strong>' . $themename . ' settings reset.</strong></p></div>';
    ?>

    <div class="wrap ">
        <div class="options_wrap">
            <h2 class="settings-title"><?php echo $themename; ?> Settings</h2>
            <form method="post">

                <?php
                foreach ($options as $value) {
                    switch ($value['type']) {
                        case "section":
                            ?>
                            <div class="section_wrap">
                                <h3 class="section_title"><?php echo $value['name']; ?></h3>
                                <div class="section_body">

                                    <?php
                                    break;
                                case 'text':
                                    ?>

                                    <div class="options_input options_text">
                                        <div class="options_desc"><?php echo $value['desc']; ?></div>
                                        <span class="labels"><label for="<?php echo $value['id']; ?>"><?php echo $value['name']; ?></label></span>
                                        <input name="<?php echo $value['id']; ?>" id="<?php echo $value['id']; ?>" type="<?php echo $value['type']; ?>" value="<?php
                                        if (get_option($value['id']) != "") {
                                            echo stripslashes(get_option($value['id']));
                                        } else {
                                            echo $value['std'];
                                        }
                                        ?>" />
                                    </div>

                                    <?php
                                    break;
                                case 'textarea':
                                    ?>
                                    <div class="options_input options_textarea">
                                        <div class="options_desc"><?php echo $value['desc']; ?></div>
                                        <span class="labels"><label for="<?php echo $value['id']; ?>"><?php echo $value['name']; ?></label></span>
                                        <textarea name="<?php echo $value['id']; ?>" type="<?php echo $value['type']; ?>" cols="" rows=""><?php
                                            if (get_option($value['id']) != "") {
                                                echo stripslashes(get_option($value['id']));
                                            } else {
                                                echo $value['std'];
                                            }
                                            ?></textarea>
                                    </div>

                                    <?php
                                    break;
                                case 'select':
                                    ?>
                                    <div class="options_input options_select">
                                        <div class="options_desc"><?php echo $value['desc']; ?></div>
                                        <span class="labels"><label for="<?php echo $value['id']; ?>"><?php echo $value['name']; ?></label></span>
                                        <select name="<?php echo $value['id']; ?>" id="<?php echo $value['id']; ?>">
                                            <?php foreach ($value['options'] as $option) { ?>
                                                <option <?php
                                                if (get_option($value['id']) == $option) {
                                                    echo 'selected="selected"';
                                                }
                                                ?>><?php echo $option; ?></option><?php } ?>
                                        </select>
                                    </div>

                                    <?php
                                    break;
                                case "radio":
                                    ?>
                                    <div class="options_input options_select">
                                        <div class="options_desc"><?php echo $value['desc']; ?></div>
                                        <span class="labels"><label for="<?php echo $value['id']; ?>"><?php echo $value['name']; ?></label></span>
                                        <?php
                                        foreach ($value['options'] as $key => $option) {
                                            $radio_setting = get_option($value['id']);
                                            if ($radio_setting != '') {
                                                if ($key == get_option($value['id'])) {
                                                    $checked = "checked=\"checked\"";
                                                } else {
                                                    $checked = "";
                                                }
                                            } else {
                                                if ($key == $value['std']) {
                                                    $checked = "checked=\"checked\"";
                                                } else {
                                                    $checked = "";
                                                }
                                            }
                                            ?>
                                            <input type="radio" name="<?php echo $value['id']; ?>" value="<?php echo $key; ?>" <?php echo $checked; ?> /><?php echo $option; ?><br />
                                        <?php } ?>
                                    </div>

                                    <?php
                                    break;
                                case "checkbox":
                                    ?>
                                    <div class="options_input options_checkbox">
                                        <div class="options_desc"><?php echo $value['desc']; ?></div>
                                        <?php
                                        if (get_option($value['id'])) {
                                            $checked = "checked=\"checked\"";
                                        } else {
                                            $checked = "";
                                        }
                                        ?>
                                        <input type="checkbox" name="<?php echo $value['id']; ?>" id="<?php echo $value['id']; ?>" value="true" <?php echo $checked; ?> />
                                        <label for="<?php echo $value['id']; ?>"><?php echo $value['name']; ?></label>
                                    </div>

                                    <?php
                                    break;
                                case "close":
                                    $i++;
                                    ?>
                                    <span class="submit"><input name="save<?php echo $i; ?>" type="submit" value="Save Changes" /></span>
                                </div><!--#section_body-->
                            </div><!--#section_wrap-->

                            <?php
                            break;
                    }
                }
                ?>

                <input type="hidden" name="action" value="save" />
                <span class="submit">
                    <input name="save" type="submit" value="Save All Changes" />
                </span>
            </form>

            <form method="post">
                <span class="submit">
                    <input name="reset" type="submit" value="Reset All Options" />
                    <input type="hidden" name="action" value="reset" />
                </span>
            </form>
            <br/>
        </div>
    </div>
    <?php
}

add_action('admin_init', 'ccp_add_init');
add_action('admin_menu', 'ccp_add_admin');

////Header Customizations
//function p2h_wp_head() {
//    //If Set in Theme Options, Add Feed URL in Head
//    if (get_option('p2h_feedurl') != '') {
//        echo '<link rel="alternate" type="application/rss+xml" href="' . get_option('p2h_feedurl') . '" title="' . get_bloginfo('name') . ' RSS Feed"/>' . "n";
//    }
//}
//
//add_action('wp_head', 'p2h_wp_head');
//
////Header Customization -- Remove Auto Feed URL
//if (get_option('p2h_feedurl') != '') {
//    // Remove the links to feed
//    remove_action('wp_head', 'feed_links', 2);
//}
//
//// Remove the links to the extra feeds such as category feeds
//if (get_option('p2h_cleanfeedurls') != '') {
//    remove_action('wp_head', 'feed_links_extra', 3);
//}

/* ------------------------------ */
/* Custom headers                 */
/* ------------------------------ */
$args = array(
    'default-image' => get_template_directory_uri() . '/images/telerik-academy.png',
    'random-default' => false,
    'width' => 1140,
    'height' => 73,
    'flex-height' => false,
    'flex-width' => false,
    'default-text-color' => '',
    'header-text' => true,
    'uploads' => true,
    'wp-head-callback' => '',
    'admin-head-callback' => '',
    'admin-preview-callback' => '',
);
add_theme_support('custom-header', $args);

/* ------------------------------ */
/* Custom backgrounds             */
/* ------------------------------ */

$args = array(
    'default-color' => '',
    'default-image' => get_template_directory_uri() . '/images/img02.png',
    'wp-head-callback' => '_custom_background_cb',
    'admin-head-callback' => '',
    'admin-preview-callback' => ''
);
add_theme_support('custom-background', $args);

/* ------------------------------ */
/* Custom editor styles           */
/* ------------------------------ */

function my_theme_add_editor_styles() {
    add_editor_style('custom-editor-style.css');
}

add_action('init', 'my_theme_add_editor_styles');


/* ------------------------------ */
/* Feed links supprot             */
/* ------------------------------ */

add_theme_support('automatic-feed-links');


/* ------------------------------ */
/* Custom testimonial widget      */
/* ------------------------------ */
wp_register_sidebar_widget(
        'testimonial_widget', 'CUSTOM - Testimonial Widget', 'testimonial_widget_display', array(
    'description' => 'A custom widget for testimonial on the from page of Telerik CMS Course Theme.'
        )
);

wp_register_widget_control(
        'testimonial_widget', // id
        'testimonial widget', // name
        'testimonial_widget_control' // callback function
);

function testimonial_widget_control() {
    //the form is submitted, save into database
    if (isset($_POST['submitted'])) {
        update_option('testimonial_widget_description', $_POST['description']);
        update_option('testimonial_widget_authorName', $_POST['authorName']);
        update_option('testimonial_widget_companyName', $_POST['companyName']);
    }

    //load options
    $authorName = get_option('testimonial_widget_authorName');
    $description = get_option('testimonial_widget_description');
    $companyName = get_option('testimonial_widget_companyName');
    ?>

    Testimonial:<br />
    <textarea class="widefat" rows="5" name="description">
        <?php echo stripslashes($description); ?>
    </textarea>
    <br /><br />

    Author name:<br />
    <input type="text" class="widefat" name="authorName" value="<?php echo stripslashes($authorName); ?>" />
    <br /><br />

    Company name:<br />
    <input type="text" class="widefat" name="companyName" value="<?php echo stripslashes($companyName); ?>" />
    <br /><br />

    <input type="hidden" name="submitted" value="1" />
    <?php
}

function testimonial_widget_display() {
    //load options
    $description = get_option('testimonial_widget_description');
    $authorName = get_option('testimonial_widget_authorName');
    $companyName = get_option('testimonial_widget_companyName');

    //widget output
    echo '<h3>Testimonials</h3>';

    echo '<div class="testimonials"><strong>"</strong>' . stripslashes(nl2br($description));
    echo '<strong>"</strong>';
    if ($authorName != '') {
        echo '<p class="author">' . stripslashes($authorName) . '';
        if ($companyName != '') {
            echo '<strong>, ' . stripslashes($companyName) . '</strong>';
        }
        echo '</p>';
    }

    echo '</div>';
}
?>