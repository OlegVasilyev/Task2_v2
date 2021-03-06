﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayerInterfaces.DataTransferObjects
{
    public class ArticleDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public List<string> Tags { get; set; }
        public List<CommentDTO> Comments { get; set; }
        public ArticleDTO()
        {
            Tags = new List<string>();
            Comments = new List<CommentDTO>();
        }
    }
}