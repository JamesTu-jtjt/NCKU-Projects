"""
The template of the script for the machine learning process in game pingpong
"""
import random


class MLPlay:
    def __init__(self, side):
        """
        Constructor

        @param side A string "1P" or "2P" indicates that the `MLPlay` is used by
               which side.
        """
        self.ball_served = False
        self.rand = random.randint(0, 16) * 10
        self.side = side
        self.block = 0

    def update(self, scene_info):
        """
        Generate the command according to the received scene information
        """
        if scene_info["status"] != "GAME_ALIVE":
            print(scene_info["ball_speed"])
            return "RESET"
        if not self.ball_served:
            ball_y = scene_info["ball"][1]
            if self.side == "1P":
                p = scene_info["platform_1P"][0]
                if ball_y == 80:
                    return "NONE"
                elif ball_y == 415:
                    if p == self.rand:
                        self.ball_served = True
                        return "SERVE_TO_LEFT" if random.randint(0, 1) else "SERVE_TO_RIGHT"
                else:
                    self.ball_served = True
            else:
                p = scene_info["platform_2P"][0]
                if ball_y == 415:
                    return "NONE"
                elif ball_y == 80:
                    if p == self.rand:
                        self.ball_served = True
                        return "SERVE_TO_LEFT" if random.randint(0, 1) else "SERVE_TO_RIGHT"
                else:
                    self.ball_served = True
            command = "MOVE_LEFT" if p > self.rand else "MOVE_RIGHT"

        else:
            ball_x = scene_info["ball"][0]
            ball_y = scene_info["ball"][1]
            ball_speed_x = scene_info["ball_speed"][0]
            ball_speed_y = scene_info["ball_speed"][1]
            slope = ball_speed_y / ball_speed_x if ball_speed_x != 0 else 0
            if "blocker" in scene_info:
                blocker = scene_info["blocker"][0]
                blocker_speed = blocker - self.block
                self.block = blocker
                if self.side == "1P":
                    platform = scene_info["platform_1P"][0] + 20
                    px = ball_x + (415 - ball_y) / slope if slope != 0 else ball_x
                    if ball_speed_y > 0:
                        if ball_y < 260:
                            for i in range(235, 261, 5):
                                hit = ball_x + (i - ball_y) / slope if slope != 0 else ball_x
                                pred_b = blocker + blocker_speed * ((i - ball_y) / ball_speed_y)
                                while hit < 0 or hit > 195:
                                    if hit < 0:
                                        hit *= -1
                                    elif hit > 195:
                                        hit = 195 - (hit - 195)
                                while pred_b < 0 or pred_b > 170:
                                    if pred_b < 0:
                                        pred_b *= - 1
                                    elif pred_b > 170:
                                        pred_b = 170 - (pred_b - 170)
                                if i == 235 and pred_b - 5 <= hit <= pred_b + 30:
                                    px = 100
                                    break
                                elif pred_b - 5 <= hit <= pred_b + 30:
                                    px = hit + -(415 - i) / slope if slope != 0 else ball_x
                                    break

                    else:
                        if ball_y >= 260:
                            hit = ball_x + (260 - ball_y) / slope if slope != 0 else ball_x
                            px = hit + (415 - 260) / -slope if slope != 0 else hit
                        else:
                            px = 100
                else:
                    platform = scene_info["platform_2P"][0] + 20
                    px = ball_x + (80 - ball_y) / slope if slope != 0 else ball_x
                    if ball_speed_y < 0:
                        if ball_y > 235:
                            for i in range(260, 236, -5):
                                hit = ball_x + (i - ball_y) / slope if slope != 0 else ball_x
                                pred_b = blocker + blocker_speed * ((i - ball_y) / ball_speed_y)
                                while hit < 0 or hit > 195:
                                    if hit < 0:
                                        hit *= -1
                                    elif hit > 195:
                                        hit = 195 - (hit - 195)
                                while pred_b < 0 or pred_b > 170:
                                    if pred_b < 0:
                                        pred_b *= - 1
                                    elif pred_b > 170:
                                        pred_b = 170 - (pred_b - 170)
                                if i == 260 and pred_b - 5 <= hit <= pred_b + 30:
                                    px = 100
                                    break
                                elif pred_b - 5 <= hit <= pred_b + 30:
                                    px = hit + -(80 - i) / slope if slope != 0 else ball_x
                                    break
                    else:
                        if ball_y <= 235:
                            hit = ball_x + (235 - ball_y) / slope if slope != 0 else ball_x
                            px = hit + (80 - 235) / -slope if slope != 0 else ball_x
                        else:
                            px = 100
            else:
                if self.side == "1P":
                    platform = scene_info["platform_1P"][0] + 20
                    px = ball_x + (415 - ball_y) / slope if slope != 0 else ball_x
                else:
                    platform = scene_info["platform_2P"][0] + 20
                    px = ball_x + (80 - ball_y) / slope if slope != 0 else ball_x
                if ball_speed_y > 0:
                    px = 100

            while px < 0 or px > 195:
                if px < 0:
                    px *= -1
                elif px > 195:
                    px = 195 - (px - 195)

            if px - 5 <= platform <= px + 5:
                command = "NONE"
            else:
                command = "MOVE_RIGHT" if platform < px else "MOVE_LEFT"

        return command

    def reset(self):
        """
        Reset the status
        """
        self.ball_served = False
        self.rand = random.randint(0, 16) * 10
        self.block = 0
