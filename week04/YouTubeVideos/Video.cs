using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    public class Video
    {
        private string _title;
        private string _author;
        private int _lengthInSeconds;
        private List<Comment> _comments;

        public Video(string title, string author, int lengthInSeconds)
        {
            _title = title;
            _author = author;
            _lengthInSeconds = lengthInSeconds;
            _comments = new List<Comment>();
        }

        public string Title => _title;
        public string Author => _author;
        public int LengthInSeconds => _lengthInSeconds;

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return _comments.Count;
        }

        public List<Comment> GetComments()
        {
            return _comments;
        }

        public string GetFormattedLength()
        {
            int minutes = _lengthInSeconds / 60;
            int seconds = _lengthInSeconds % 60;
            return $"{minutes}:{seconds:D2}";
        }
    }
}