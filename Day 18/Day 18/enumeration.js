var Status;
(function (Status) {
    Status["Pending"] = "PENDING";
    Status["InProgress"] = "IN_PROGRESS";
    Status["Complete"] = "COMPLETE";
})(Status || (Status = {}));
console.log(Status.Pending); // Output: PENDING
console.log(Status.InProgress); // Output: IN_PROGRESS
console.log(Status.Complete); // Output: COMPLETE
console.log(Status[0]); // Output: PENDING
