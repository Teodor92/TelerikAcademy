<!DOCTYPE HTML>
<html <?php language_attributes(); ?>>
    <head>
        <title><?php bloginfo('name'); ?> <?php wp_title(); ?></title>
        <meta http-equiv="content-type" content="text/html; charset=utf-8" />
        <meta name="description" content="" />
        <meta name="keywords" content="" />
        <link href="<?php bloginfo('stylesheet_url') ?>" rel="stylesheet" />
        <?php wp_head(); ?>
    </head>

    <body <?php body_class(); ?> class="custom-background">
        <div id="wrapper">
            <div id="header-wrapper">
                <header id="header">
                    <div class="5grid-layout 5grid">
                        <div class="row">
                            <div class="12u" id="logo"> <!-- Logo -->
                                <h1><a href="<?php echo home_url(); ?>" class="mobileUI-site-name">
                                        <?php bloginfo('name'); ?>
                                    </a>
                                </h1>
                                <p><?php bloginfo('description'); ?></p>
                            </div>
                        </div>
                    </div>
                    <div class="5grid-layout 5grid">
                        <div class="row">
                            <div class="12u" id="menu">
                                <div id="menu-wrapper">
                                    <nav class="mobileUI-site-nav">
                                        <?php
                                        /* Dynamic menu if available */
                                        if (!function_exists('wp_nav_menu')) {
                                            $args = array(
                                                'depth' => 1,
                                                'show_home' => true);
                                            wp_page_menu($args);
                                        } else {
                                            wp_nav_menu(array(
                                                'theme_location' => 'main',
                                                'fallback_cb' => 'fallbacknav'));
                                        }
                                        ?>
                                    </nav>
                                </div>
                            </div>
                        </div>
                    </div>
                </header>
            </div>
            <div id="page-wrapper" class="5grid-layout 5grid">
                <div class="5grid-layout">
                    <div class="row">
                        <div class="12u">
                            <div id="banner">
                                <img src="<?php header_image(); ?>" height="<?php echo get_custom_header()->height; ?>" width="<?php echo get_custom_header()->width; ?>" alt="Custom header" />
                            </div>
                        </div>
                    </div>
