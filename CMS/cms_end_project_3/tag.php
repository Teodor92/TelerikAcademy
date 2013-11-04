<?php get_header(); ?>
<div class="5grid-layout 5grid">
    <div class="row">
        <div class="9u">

            <?php
            $temp = $wp_query;
            $wp_query = null;
            $wp_query = new WP_Query();
            $wp_query->query('showposts=5' . '&paged=' . $paged);

            if ($wp_query->have_posts()):
                ?>
            <div id="content">
            <?php
                while ($wp_query->have_posts()):

                    the_post()
                    ?>
                    
                        <section>
                            <div class="post">
                                <h2><a href="<?php the_permalink() ?>"><?php the_title() ?></a></h2>
                                <p>
                                    <a href="<?php the_permalink() ?>">
                                        <?php if (has_post_thumbnail()) { ?>
                                            <?php the_post_thumbnail(); ?>
                                        <?php } ?>
                                    </a>
                                    <?php the_excerpt(); ?>
                                </p>
                                <div class="category">
                                    Categories:
                                    <?php
                                    the_category(', ');
                                    ?>
                                </div>
                                <div class="tags">
                                    <?php
                                    the_tags();
                                    ?>
                                </div>
                        </section>
                    

                    <?php
                endwhile; // ends the have_post loop
                ?>
                </div>
                <?php
            endif; // ends the have_post if
            ?>
        </div>        
        <div class="3u">
            <div id="sidebar2">
                <section>
                    <ul class="sidebars">
                        <?php get_sidebar('main'); ?>
                    </ul>							
                </section>
            </div>
        </div>
    </div>
</div>
</div>
</div>
<?php get_footer(); ?>
