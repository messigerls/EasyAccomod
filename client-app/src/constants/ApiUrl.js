const ApiUrl = {
    GET_TOKEN: 'api/account/token',
    GET_ACCOUNT_INFO: 'api/account/info',
    OWNER_REGISTER: 'api/Account/OwnerRegister',
    RENTER_REGISTER: 'api/Account/RenterRegister',

    GET_ALL_PROVINCE: 'api/Provinces',
    GET_DISTRICT_BY_PROVINCE_ID: (provinceId) =>
        `api/Provinces/${provinceId}/districts`,
    GET_WARD_BY_DISTRICT_ID: (districtId) =>
        `api/Districts/${districtId}/Wards`,
    GET_ALL_ROOM_TYPE: 'api/Accommodations/Types',

    GET_ALL_ROOM_AREA_TYPE: 'api/Accommodations/RoomAreaRanges',
    GET_ALL_KITCHEN_TYPE: 'api/Accommodations/KitchenTypes',
    GET_ALL_ROOM_PAYMENT_TYPE: 'api/Accommodations/PaymentTypes',

    GET_RENTAL_POST: '/api/RentalPosts/Search',
    POST_RENTAL_POST: '/api/RentalPosts',

    CLOUDINARY_UPLOAD_URL:
        'https://api.cloudinary.com/v1_1/dsysolkex/image/upload',
};
export default ApiUrl;
