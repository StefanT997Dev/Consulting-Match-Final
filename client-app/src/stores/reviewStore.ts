import { makeAutoObservable } from "mobx";
import { Review } from "../models/review";
import { v4 as uuid } from 'uuid';
import { Consultant } from "../models/consultant";
import agent from "../api/agent";

export default class ReviewStore{
    review: Review | undefined=undefined;
    reviewsForSelectedConsultant:Review[]=[];

    constructor(){
        makeAutoObservable(this);
    }

    setReview=(starReview:number | string | undefined,commentReview:string | number | undefined)=>{
        this.review={
            id:uuid(),
            starRating:starReview,
            comment:commentReview
        }
    }

    getReviewsForSelectedConsultant= async (consultant:Consultant | undefined)=>{
        var reviews:Review[] = await agent.Consultants.getListOfReviews(consultant);

        reviews.forEach(review => {
            this.reviewsForSelectedConsultant.push(review);
        });
    }
}