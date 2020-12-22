import axiosClient from './axiosClient';
import ApiUrl from '../constants/ApiUrl';
const rentalPost = {
    getPostBySearch(query) {
        const url = ApiUrl.GET_RENTAL_POST + '?' + query;
        console.log(url);
        return axiosClient.get(url);
    },
    postNewPost(data) {
        const url = ApiUrl.POST_RENTAL_POST;
        const {
            title,
            description,
            roomType,
            accommodationPictures,
            province,
            district,
            ward,
            street,
            roomPrice,
            roomArea,
            roomQuantity,
            liveWithOwner,
            closeBathroom,
            haveWaterHeader,
            haveAirCondition,
            haveBalcony,
            waterElectricity,
            electricityPrice,
            waterPrice,
            kitchenType,
            publicLocationNearby,
            owner,
            roomPaymentType,
            roomOption,
            packageType,
            numberOfTime,
        } = data;
        const ownerId = owner ? owner.id : 0;
        const body = {
            Title: title,
            Content: description,
            AccommodationPictures: accommodationPictures,
            Accommodation: {
                Address: {
                    ProvinceId: province.value,
                    DistrictId: district.value,
                    WardId: ward.value,
                    Street: street,
                    PublicLocationNearby: publicLocationNearby,
                },
                AccommodationTypeId: roomType.value,
                RoomQuantity: roomQuantity,
                PaymentTypeId: roomPaymentType.value,
                Price: roomPrice,
                RoomAreaRangeId: roomArea.value,
                LiveWithOwner: liveWithOwner,
                HaveClosedBathroom: closeBathroom,
                HaveWaterHeater: haveWaterHeader,
                KitchenTypeId: kitchenType.value,
                HaveAirConditioner: haveAirCondition,
                HaveBalcony: haveBalcony,
                IsStateElectricityPrice: waterElectricity === 'normal',
                ElectricityPrice: electricityPrice,
                IsStateWaterPrice: waterElectricity === 'normal',
                WaterPrice: waterPrice,
                RoomOptions: roomOption,
                OwnerId: ownerId,
            },
            TimeDisplayed: Number(packageType.day) * Number(numberOfTime),
        };
        console.log(body);
        return axiosClient.post(url, body);
    },
    getRentalPostInfo(id) {
        const url = ApiUrl.GET_RENTAL_POST_INFO + id;
        return axiosClient.get(url);
    },
    postComment(params) {
        const url = ApiUrl.POST_COMMENT;
        return axiosClient.post(url, params);
    },
    getAllCommentByPostId(postId, _limit, _page) {
        const url = ApiUrl.GET_ALL_RENTAL_POST_COMMENT(postId, _limit, _page);
        return axiosClient.get(url);
    },
    getViews(postId) {
        const url = ApiUrl.GET_VIEW(postId);
        return axiosClient.get(url);
    },
    getLikes(postId) {
        const url = ApiUrl.GET_LIKE(postId);
        return axiosClient.get(url);
    },
    getRenterIsLikeRentalPost(postId) {},
    postRenterLikeRentalPost(postId) {
        const url = ApiUrl.POST_LIKE_RENTAL_POST;
        return axiosClient.post(url, { AccommodationRentalPostId: postId });
    },
    getAllFavoriteRentalPost() {
        const url = ApiUrl.GET_ALL_FAVORITE_RENTAL_POST;
        return axiosClient.get(url);
    },
    postReport(params) {
        const url = ApiUrl.POST_REPORT;
        return axiosClient.post(url, params);
    },
    isLiked(postId) {
        const url = ApiUrl.IS_LIKED + '?postId=' + postId;
        return axiosClient.get(url);
    },
    isCommented(postId) {
        const url = ApiUrl.IS_COMMENTED + '?postId=' + postId;
        return axiosClient.get(url);
    },
    isReported(postId) {
        const url = ApiUrl.IS_REPORTED + '?postId=' + postId;
        return axiosClient.get(url);
    },
};

export default rentalPost;
