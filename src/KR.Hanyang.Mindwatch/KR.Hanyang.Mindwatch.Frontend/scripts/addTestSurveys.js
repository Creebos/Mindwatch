import axios from "axios";

const testSurveys = [
    {
        description: "Test Survey 1",
        questions: [
            { questionText: "How are you feeling today?" },
            { questionText: "Rate your stress level from 1 to 10." }
        ]
    },
    {
        description: "Test Survey 2",
        questions: [
            { questionText: "What did you eat today?" },
            { questionText: "Did you get enough sleep last night?" }
        ]
    }
];

const addSurvey = async (survey) => {
    try {
        const response = await axios.post("http://localhost:8081/api/questionnaires", survey, {
            headers: {
                "Content-Type": "application/json",
            },
        });
        console.log("Survey added successfully:", response.data);
    } catch (error) {
        console.error("Error adding survey:", error.response?.data || error.message);
    }
};

const addTestSurveys = async () => {
    for (const survey of testSurveys) {
        await addSurvey(survey);
    }
};

addTestSurveys();
