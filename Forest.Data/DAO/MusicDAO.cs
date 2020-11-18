﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forest.Data.BEANS;
using Forest.Data.IDAO;

namespace Forest.Data.DAO
{
    public class MusicDAO : IMusicDAO
    {
        private ForestEntities _context;
        public MusicDAO() { _context = new ForestEntities(); }



        //public Music_Recording GetMusicRecording(int id)

        //{
        //    IQueryable<Music_Recording> _recording;
        //    _recording = from recording
        //                 in _context.Music_Recording
        //                 where recording.Id == id
        //                 select recording;
        //    return _recording.ToList<Music_Recording>().First();


        //}

        public MusicBEAN GetMusicRecording (int id)
        {
            IQueryable<MusicBEAN> _musicBEAN = from rec in _context.Music_Recording
                                               from cat in _context.Music_Category
                                               where rec.GenreId == cat.GenreId
                                               where cat.GenreId == id
                                               select new MusicBEAN
                                               {
                                                   Id = rec.GenreId,
                                                   Artist = rec.Artist,
                                                   Title = rec.Title,
                                                   Genre = cat.Genre,
                                                   Image_Name = rec.Image_Name,
                                                   Num_Tracks = rec.Num_Tracks,
                                                   Price = rec.Price,
                                                   Stock_Count = rec.Stock_Count,
                                                   Released = rec.Released,
                                               };
            return _musicBEAN.ToList().First();
        }
   

        public IList<MusicBEAN> GetMusicRecordings(int genre)
        {
            IQueryable<MusicBEAN> _musicBEANS = from recs in _context.Music_Recording
                                                from cats in _context.Music_Category
                                                where recs.GenreId == cats.GenreId
                                                where cats.GenreId == genre
                                                select new MusicBEAN
                                                {
                                                    Id = recs.GenreId,
                                                    Artist = recs.Artist,
                                                    Title = recs.Title,
                                                    Genre = cats.Genre,
                                                    Image_Name = recs.Image_Name,
                                                    Num_Tracks = recs.Num_Tracks,
                                                    Price = recs.Price,
                                                    Stock_Count = recs.Stock_Count,
                                                    Released = recs.Released,

                                                };
            return _musicBEANS.ToList<MusicBEAN>();
        }




        
      //public IList<Music_Recording> GetMusicRecordings(int genre)
      //  {

      //      IQueryable<Music_Recording>_recordings;
      //      _recordings = from recording
      //                    in _context.Music_Recording
      //                    where recording.GenreId == genre
      //                    select recording;
      //      return _recordings.ToList<Music_Recording>();

      //      //Select * from Music_Recording as recording
      //      //    where recording.genre==myGenre
          
      //  //This is a method to call information from the Music_Recording table.

      //  }


	public IList<Music_Category> GetMusicCategories()
		{

            IQueryable<Music_Category> _categories;
            _categories = from category
                          in _context.Music_Category
                          select category;
            return _categories.ToList();




        }



    public void EditMusicRecording(MusicBEAN recording)

        {

            MusicBEAN record = GetMusicRecording(recording.Id);
            record.Artist = recording.Artist;
            record.Genre = recording.Genre;
            record.Image_Name = recording.Image_Name;
            record.Num_Tracks = recording.Num_Tracks;
            record.Price = recording.Price;
            record.Released = recording.Released;
            record.Stock_Count = recording.Stock_Count;
            record.Title = recording.Title;
            //record.Url = recording.Url;
            _context.SaveChanges();



            
        }

    public void AddMusicRecording(Music_Recording recording)

        {

            _context.Music_Recording.Add(recording);
            _context.SaveChanges();



        }



    public void DeleteMusicRecording(Music_Recording recording)
        {


            _context.Music_Recording.Remove (recording);
            _context.SaveChanges();



        }

    

    }
}
