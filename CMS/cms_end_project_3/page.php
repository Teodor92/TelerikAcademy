<?php get_header() ?>
<div class="5grid-layout 5grid">
    <div class="row">
        <div class="9u">

            <?php
            if (have_posts()):
                ?>
                <div id="content">
                    <?php
                    while (have_posts()):

                        the_post();
                        ?>

                        <section>
                            <div class="post">
                                <h2>
                                    <a href="<?php the_permalink() ?>">
                                        <?php the_title() ?>
                                    </a>
                                </h2>
                                <p>
                                    <?php the_content(); ?>
                                </p>
                                <div class="tags">
                                    <?php
                                    the_tags();
                                    ?>
                                </div>
                        </section>
                        <!-- comments for a given post -->
                        <ol class="commentlist">
                            <?php
                            //Gather comments for a specific page/post 
                            $comments = get_comments(array(
                                'post_id' => get_the_ID(),
                                'status' => 'approve' //Change this to the type of comments to be displayed
                            ));

                            //Display the list of comments
                            wp_list_comments(array(
                                'reverse_top_level' => false //Show the latest comments at the top of the list
                                    ), $comments);
                            ?>

                            <div class="pagination">
                                <?php paginate_comments_links(); ?>
                            </div>
                        </ol>
                        <div>
                            <?php comment_form() ?>
                        </div>
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
<?php get_footer() ?>