enum Status {
    Pending = 'PENDING',
    InProgress = 'IN_PROGRESS',
    Complete = 'COMPLETE'
    }
    
    console.log(Status.Pending); // Output: PENDING
    console.log(Status.InProgress); // Output: IN_PROGRESS
    console.log(Status.Complete); // Output: COMPLETE
    console.log(Status[0]); // Output: PENDING