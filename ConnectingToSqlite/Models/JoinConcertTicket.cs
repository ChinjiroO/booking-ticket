using System;

public class JoinConcertTicket
{
    int _id;
    int _concertId;
    string _title;
    DateTime _showDate;
    string _location;
    byte _statusId;
    string _reservedBy;
    DateTime _reservedDate;

    public int Id 
    { 
	    get { return _id; } 
        set { _id = value; }
    }
    public int ConcertId
    { 
        get { return _concertId; }
        set { _concertId = value; }
    }
    public string Title 
    { 
	    get { return _title; } 
	    set { _title = value; } 
    }
    public DateTime ShowDate
    { 
	    get { return _showDate; } 
	    set { _showDate = value; } 
    }
    public string Location
    { 
	    get { return _location; } 
	    set { _location = value; } 
    }
    public byte StatusId
    { 
	    get { return _statusId; } 
	    set { _statusId = value; } 
    }
    public string ReservedBy
    { 
	    get { return _reservedBy; } 
	    set { _reservedBy = value; } 
    }
    public DateTime ReservedDate 
    { 
	    get { return _reservedDate; } 
	    set { _reservedDate = value; } 
    }
} 