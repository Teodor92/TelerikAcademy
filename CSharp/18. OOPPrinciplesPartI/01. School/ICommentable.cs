using System;
using System.Collections.Generic;

public interface ICommentable
{
    List<string> Comments { get; set; }

    void AddComment(string comment);
}